using System.ComponentModel;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Framework
{
  
    public class ObjectCollection<T> : BindingList<T> where T : BaseEntity
    {       
        #region Member fields

        private List<T> _deletedEntities;

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new empty list of entyties.
        /// </summary>
        public ObjectCollection()
            : base()
        {
            this.AllowNew = true;
            _deletedEntities = new List<T>();
        }

        /// <summary>
        /// Create a new empty list of entyties.
        /// </summary>
        public ObjectCollection(IList<T> objectsList)
            : base(objectsList)
        {
            this.AllowNew = true;
            _deletedEntities = new List<T>(); 
        }

        #endregion

        /// <summary>
        /// Indicates that the data of this list is in editing mode.
        /// This method will keep the original state of this entity althought 
        /// its data is modified. You must call EndEdit() method when the editting
        /// is completed
        /// </summary>
        /// <remarks></remarks>
        public void BeginEdit()
        {
            this.RaiseListChangedEvents = false;
        }

        /// <summary>
        /// Completed editting data.
        /// </summary>
        /// <remarks></remarks>
        public void EndEdit()
        {
            this.RaiseListChangedEvents = true;
        }

        /// <summary>
        /// Gets all entities that have Added, Modified and Deleted state.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public ObjectCollection<T> GetChanges()
        {
            // We need to return all items that have been changed, including the delted rows
            ObjectCollection<T> changedItems = new ObjectCollection<T>();
            changedItems.BeginEdit();
            foreach (T item in this.Items)
            {
                // return any item that has been changed
                if (item.EntityState != EntityState.Unchanged)
                {
                    changedItems.Add(item);
                }
            }
            // Get the deleted items
            foreach (T item in _deletedEntities)
            {
                changedItems.Add(item);
            }
            changedItems.EndEdit();
            // return all the changed items (deleted, modified, added)
            return changedItems;
        }

        /// <summary>
        /// Gets all entities that have the specific state.
        /// </summary>
        /// <param name="state">The state of entities that you want to get.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public ObjectCollection<T> GetChanges(EntityState state)
        {
            ObjectCollection<T> changedItems = new ObjectCollection<T>();
            if (state == EntityState.Deleted)
            {
                foreach (T item in _deletedEntities)
                    changedItems.Add(item);
            }
            else
            {
                foreach (T item in this.Items)
                {
                    if (item.EntityState == state)
                        changedItems.Add(item);
                }
            }
            return changedItems;
        }

        /// <summary>
        /// Accepts all changes. After calls AcceptChanges(), you cannot RejectChanges().
        /// The entity will return to Unchanged state.
        /// </summary>
        public void AcceptChanges()
        {
            foreach (T item in this.Items)
            {
                item.AcceptChanges();
            }
            _deletedEntities.Clear();
        }

        /// <summary>
        /// Accepts all the deletions of this collection. 
        /// After calls AcceptDeletions(), you cannot recover these deleted items.
        /// </summary>
        public void AcceptDeletions()
        {
            _deletedEntities.Clear();
        }


    }
}