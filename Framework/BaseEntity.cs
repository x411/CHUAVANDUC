using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Reflection;

namespace Framework
{
    
    public class BaseEntity : INotifyPropertyChanged, ICloneable
    {
        protected EntityState _state;
        protected bool _isEditing;

        #region Constructor

        /// <summary>
        /// Constructor, set added to the entity when it was created
        /// </summary>
        public BaseEntity()
        {
            _state = EntityState.Added;
            _isEditing = false;
        }

        #endregion

        /// <summary>
        /// Gets the value indicates that the state of this entity is added or not.
        /// </summary>
        public bool IsAdded
        {
            get
            {
                return (_state == EntityState.Added);
            }
        }

        /// <summary>
        /// Gets the value indicates that the state of this entity is modified or not.
        /// </summary>
        public bool IsModified
        {
            get
            {
                return (_state == EntityState.Modified);
            }
        }

        /// <summary>
        /// Gets the value indicates that the state of this entity is modified or not.
        /// </summary>
        public bool IsDeleted
        {
            get
            {
                return (_state == EntityState.Deleted);
            }
        }

        /// <summary>
        /// Gets the value indicates that the state of this entity is unchanged or not.
        /// </summary>
        public bool IsUnchanged
        {
            get
            {
                return (_state == EntityState.Unchanged);
            }
        }

        internal EntityState EntityState
        {
            get
            {
                return _state;
            }
            set
            {
                _state = value;
            }
        }

        /// <summary>
        /// Keep the original status of the entity
        /// </summary>
        public void BeginEdit()
        {
            _isEditing = true;
        }

        /// <summary>
        /// Ends editing
        /// </summary>
        public void EndEdit()
        {
            _isEditing = false;
        }

        /// <summary>
        /// Accepts all changes
        /// </summary>
        public void AcceptChanges()
        {
            _state = EntityState.Unchanged;
        }

        /// <summary>
        /// Gets the value of a field
        /// </summary>
        /// <param name="propertyName">The name of a field</param>
        /// <returns>Value of this field</returns>
        public object GetValue(string propertyName)
        {
            return this.GetType().GetProperty(propertyName).GetValue(this, null);
        }

        /// <summary>
        /// Sets the value for a field
        /// </summary>
        /// <param name="propertyName">The name of a field</param>
        /// <param name="value">Value of this field</value>
        public void SetValue(string propertyName, object value)
        {
            PropertyInfo property = this.GetType().GetProperty(propertyName);
            if (property != null)
            {
                property.SetValue(this, value, null);
            }
        }

        /// <summary>
        /// Change the state of the entity
        /// </summary>
        /// <param name="dataState"></param>
        /// <param name="propertyName"></param>
        protected void DataStateChanged(EntityState dataState, string propertyName)
        {
            if (!_isEditing)
            {
                if (!(string.IsNullOrEmpty(propertyName)))
                {
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                    }
                }
                if (this._state == EntityState.Unchanged && dataState == EntityState.Modified)
                {
                    this._state = dataState;
                }
                else
                {
                    if (dataState == EntityState.Deleted)
                    {
                        this._state = EntityState.Deleted;
                    }
                }
            }
        }


        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region ICloneable Members

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        #endregion
    }
}
