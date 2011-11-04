//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization;

namespace RSSFeedService
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(ROLE))]
    [KnownType(typeof(STATUS))]
    [KnownType(typeof(ITEM))]
    [KnownType(typeof(FEED))]
    public partial class USER: IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region Primitive Properties
    
        [DataMember]
        public long user_id
        {
            get { return _user_id; }
            set
            {
                if (_user_id != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'user_id' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    _user_id = value;
                    OnPropertyChanged("user_id");
                }
            }
        }
        private long _user_id;
    
        [DataMember]
        public string user_email
        {
            get { return _user_email; }
            set
            {
                if (_user_email != value)
                {
                    _user_email = value;
                    OnPropertyChanged("user_email");
                }
            }
        }
        private string _user_email;
    
        [DataMember]
        public string user_password
        {
            get { return _user_password; }
            set
            {
                if (_user_password != value)
                {
                    _user_password = value;
                    OnPropertyChanged("user_password");
                }
            }
        }
        private string _user_password;
    
        [DataMember]
        public long status_id
        {
            get { return _status_id; }
            set
            {
                if (_status_id != value)
                {
                    ChangeTracker.RecordOriginalValue("status_id", _status_id);
                    if (!IsDeserializing)
                    {
                        if (STATUS != null && STATUS.status_id != value)
                        {
                            STATUS = null;
                        }
                    }
                    _status_id = value;
                    OnPropertyChanged("status_id");
                }
            }
        }
        private long _status_id;
    
        [DataMember]
        public long role_id
        {
            get { return _role_id; }
            set
            {
                if (_role_id != value)
                {
                    ChangeTracker.RecordOriginalValue("role_id", _role_id);
                    if (!IsDeserializing)
                    {
                        if (ROLE != null && ROLE.role_id != value)
                        {
                            ROLE = null;
                        }
                    }
                    _role_id = value;
                    OnPropertyChanged("role_id");
                }
            }
        }
        private long _role_id;
    
        [DataMember]
        public bool user_connected
        {
            get { return _user_connected; }
            set
            {
                if (_user_connected != value)
                {
                    _user_connected = value;
                    OnPropertyChanged("user_connected");
                }
            }
        }
        private bool _user_connected;
    
        [DataMember]
        public string user_key
        {
            get { return _user_key; }
            set
            {
                if (_user_key != value)
                {
                    _user_key = value;
                    OnPropertyChanged("user_key");
                }
            }
        }
        private string _user_key;

        #endregion
        #region Navigation Properties
    
        [DataMember]
        public ROLE ROLE
        {
            get { return _rOLE; }
            set
            {
                if (!ReferenceEquals(_rOLE, value))
                {
                    var previousValue = _rOLE;
                    _rOLE = value;
                    FixupROLE(previousValue);
                    OnNavigationPropertyChanged("ROLE");
                }
            }
        }
        private ROLE _rOLE;
    
        [DataMember]
        public STATUS STATUS
        {
            get { return _sTATUS; }
            set
            {
                if (!ReferenceEquals(_sTATUS, value))
                {
                    var previousValue = _sTATUS;
                    _sTATUS = value;
                    FixupSTATUS(previousValue);
                    OnNavigationPropertyChanged("STATUS");
                }
            }
        }
        private STATUS _sTATUS;
    
        [DataMember]
        public TrackableCollection<ITEM> ITEM
        {
            get
            {
                if (_iTEM == null)
                {
                    _iTEM = new TrackableCollection<ITEM>();
                    _iTEM.CollectionChanged += FixupITEM;
                }
                return _iTEM;
            }
            set
            {
                if (!ReferenceEquals(_iTEM, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_iTEM != null)
                    {
                        _iTEM.CollectionChanged -= FixupITEM;
                    }
                    _iTEM = value;
                    if (_iTEM != null)
                    {
                        _iTEM.CollectionChanged += FixupITEM;
                    }
                    OnNavigationPropertyChanged("ITEM");
                }
            }
        }
        private TrackableCollection<ITEM> _iTEM;
    
        [DataMember]
        public TrackableCollection<FEED> FEED
        {
            get
            {
                if (_fEED == null)
                {
                    _fEED = new TrackableCollection<FEED>();
                    _fEED.CollectionChanged += FixupFEED;
                }
                return _fEED;
            }
            set
            {
                if (!ReferenceEquals(_fEED, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_fEED != null)
                    {
                        _fEED.CollectionChanged -= FixupFEED;
                    }
                    _fEED = value;
                    if (_fEED != null)
                    {
                        _fEED.CollectionChanged += FixupFEED;
                    }
                    OnNavigationPropertyChanged("FEED");
                }
            }
        }
        private TrackableCollection<FEED> _fEED;

        #endregion
        #region ChangeTracking
    
        protected virtual void OnPropertyChanged(String propertyName)
        {
            if (ChangeTracker.State != ObjectState.Added && ChangeTracker.State != ObjectState.Deleted)
            {
                ChangeTracker.State = ObjectState.Modified;
            }
            if (_propertyChanged != null)
            {
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        protected virtual void OnNavigationPropertyChanged(String propertyName)
        {
            if (_propertyChanged != null)
            {
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged{ add { _propertyChanged += value; } remove { _propertyChanged -= value; } }
        private event PropertyChangedEventHandler _propertyChanged;
        private ObjectChangeTracker _changeTracker;
    
        [DataMember]
        public ObjectChangeTracker ChangeTracker
        {
            get
            {
                if (_changeTracker == null)
                {
                    _changeTracker = new ObjectChangeTracker();
                    _changeTracker.ObjectStateChanging += HandleObjectStateChanging;
                }
                return _changeTracker;
            }
            set
            {
                if(_changeTracker != null)
                {
                    _changeTracker.ObjectStateChanging -= HandleObjectStateChanging;
                }
                _changeTracker = value;
                if(_changeTracker != null)
                {
                    _changeTracker.ObjectStateChanging += HandleObjectStateChanging;
                }
            }
        }
    
        private void HandleObjectStateChanging(object sender, ObjectStateChangingEventArgs e)
        {
            if (e.NewState == ObjectState.Deleted)
            {
                ClearNavigationProperties();
            }
        }
    
        protected bool IsDeserializing { get; private set; }
    
        [OnDeserializing]
        public void OnDeserializingMethod(StreamingContext context)
        {
            IsDeserializing = true;
        }
    
        [OnDeserialized]
        public void OnDeserializedMethod(StreamingContext context)
        {
            IsDeserializing = false;
            ChangeTracker.ChangeTrackingEnabled = true;
        }
    
        protected virtual void ClearNavigationProperties()
        {
            ROLE = null;
            STATUS = null;
            ITEM.Clear();
            FEED.Clear();
        }

        #endregion
        #region Association Fixup
    
        private void FixupROLE(ROLE previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.USER.Contains(this))
            {
                previousValue.USER.Remove(this);
            }
    
            if (ROLE != null)
            {
                if (!ROLE.USER.Contains(this))
                {
                    ROLE.USER.Add(this);
                }
    
                role_id = ROLE.role_id;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("ROLE")
                    && (ChangeTracker.OriginalValues["ROLE"] == ROLE))
                {
                    ChangeTracker.OriginalValues.Remove("ROLE");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("ROLE", previousValue);
                }
                if (ROLE != null && !ROLE.ChangeTracker.ChangeTrackingEnabled)
                {
                    ROLE.StartTracking();
                }
            }
        }
    
        private void FixupSTATUS(STATUS previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.USER.Contains(this))
            {
                previousValue.USER.Remove(this);
            }
    
            if (STATUS != null)
            {
                if (!STATUS.USER.Contains(this))
                {
                    STATUS.USER.Add(this);
                }
    
                status_id = STATUS.status_id;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("STATUS")
                    && (ChangeTracker.OriginalValues["STATUS"] == STATUS))
                {
                    ChangeTracker.OriginalValues.Remove("STATUS");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("STATUS", previousValue);
                }
                if (STATUS != null && !STATUS.ChangeTracker.ChangeTrackingEnabled)
                {
                    STATUS.StartTracking();
                }
            }
        }
    
        private void FixupITEM(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (ITEM item in e.NewItems)
                {
                    if (!item.USER.Contains(this))
                    {
                        item.USER.Add(this);
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("ITEM", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (ITEM item in e.OldItems)
                {
                    if (item.USER.Contains(this))
                    {
                        item.USER.Remove(this);
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("ITEM", item);
                    }
                }
            }
        }
    
        private void FixupFEED(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (FEED item in e.NewItems)
                {
                    if (!item.USER.Contains(this))
                    {
                        item.USER.Add(this);
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("FEED", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (FEED item in e.OldItems)
                {
                    if (item.USER.Contains(this))
                    {
                        item.USER.Remove(this);
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("FEED", item);
                    }
                }
            }
        }

        #endregion
    }
}