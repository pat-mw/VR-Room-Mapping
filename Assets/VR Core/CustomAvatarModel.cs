using Normal.Realtime;
using patmw.XR;
using Normal.Realtime.Serialization;

[RealtimeModel]
public partial class CustomAvatarModel
{
    [RealtimeProperty(1, true)] private RealtimeAvatar.DeviceType _deviceType;
    [RealtimeProperty(2, true)] private string _deviceModel;
    [RealtimeProperty(3, true, true)] private bool _headActive;
    [RealtimeProperty(4, true, true)] private bool _leftHandActive;
    [RealtimeProperty(5, true, true)] private bool _rightHandActive;
    [RealtimeProperty(6, true, true)] private bool _avatarMeshActive;
}                                                                                                                                                                   

/* ----- Begin Normal Autogenerated Code ----- */
public partial class CustomAvatarModel : RealtimeModel {
    public Normal.Realtime.RealtimeAvatar.DeviceType deviceType {
        get {
            return _cache.LookForValueInCache(_deviceType, entry => entry.deviceTypeSet, entry => entry.deviceType);
        }
        set {
            if (this.deviceType == value) return;
            _cache.UpdateLocalCache(entry => { entry.deviceTypeSet = true; entry.deviceType = value; return entry; });
            InvalidateReliableLength();
        }
    }
    
    public string deviceModel {
        get {
            return _cache.LookForValueInCache(_deviceModel, entry => entry.deviceModelSet, entry => entry.deviceModel);
        }
        set {
            if (this.deviceModel == value) return;
            _cache.UpdateLocalCache(entry => { entry.deviceModelSet = true; entry.deviceModel = value; return entry; });
            InvalidateReliableLength();
        }
    }
    
    public bool headActive {
        get {
            return _cache.LookForValueInCache(_headActive, entry => entry.headActiveSet, entry => entry.headActive);
        }
        set {
            if (this.headActive == value) return;
            _cache.UpdateLocalCache(entry => { entry.headActiveSet = true; entry.headActive = value; return entry; });
            InvalidateReliableLength();
            FireHeadActiveDidChange(value);
        }
    }
    
    public bool leftHandActive {
        get {
            return _cache.LookForValueInCache(_leftHandActive, entry => entry.leftHandActiveSet, entry => entry.leftHandActive);
        }
        set {
            if (this.leftHandActive == value) return;
            _cache.UpdateLocalCache(entry => { entry.leftHandActiveSet = true; entry.leftHandActive = value; return entry; });
            InvalidateReliableLength();
            FireLeftHandActiveDidChange(value);
        }
    }
    
    public bool rightHandActive {
        get {
            return _cache.LookForValueInCache(_rightHandActive, entry => entry.rightHandActiveSet, entry => entry.rightHandActive);
        }
        set {
            if (this.rightHandActive == value) return;
            _cache.UpdateLocalCache(entry => { entry.rightHandActiveSet = true; entry.rightHandActive = value; return entry; });
            InvalidateReliableLength();
            FireRightHandActiveDidChange(value);
        }
    }
    
    public bool avatarMeshActive {
        get {
            return _cache.LookForValueInCache(_avatarMeshActive, entry => entry.avatarMeshActiveSet, entry => entry.avatarMeshActive);
        }
        set {
            if (this.avatarMeshActive == value) return;
            _cache.UpdateLocalCache(entry => { entry.avatarMeshActiveSet = true; entry.avatarMeshActive = value; return entry; });
            InvalidateReliableLength();
            FireAvatarMeshActiveDidChange(value);
        }
    }
    
    public delegate void PropertyChangedHandler<in T>(CustomAvatarModel model, T value);
    public event PropertyChangedHandler<bool> headActiveDidChange;
    public event PropertyChangedHandler<bool> leftHandActiveDidChange;
    public event PropertyChangedHandler<bool> rightHandActiveDidChange;
    public event PropertyChangedHandler<bool> avatarMeshActiveDidChange;
    
    private struct LocalCacheEntry {
        public bool deviceTypeSet;
        public Normal.Realtime.RealtimeAvatar.DeviceType deviceType;
        public bool deviceModelSet;
        public string deviceModel;
        public bool headActiveSet;
        public bool headActive;
        public bool leftHandActiveSet;
        public bool leftHandActive;
        public bool rightHandActiveSet;
        public bool rightHandActive;
        public bool avatarMeshActiveSet;
        public bool avatarMeshActive;
    }
    
    private LocalChangeCache<LocalCacheEntry> _cache = new LocalChangeCache<LocalCacheEntry>();
    
    public enum PropertyID : uint {
        DeviceType = 1,
        DeviceModel = 2,
        HeadActive = 3,
        LeftHandActive = 4,
        RightHandActive = 5,
        AvatarMeshActive = 6,
    }
    
    public CustomAvatarModel() : this(null) {
    }
    
    public CustomAvatarModel(RealtimeModel parent) : base(null, parent) {
    }
    
    protected override void OnParentReplaced(RealtimeModel previousParent, RealtimeModel currentParent) {
        UnsubscribeClearCacheCallback();
    }
    
    private void FireHeadActiveDidChange(bool value) {
        try {
            headActiveDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }
    
    private void FireLeftHandActiveDidChange(bool value) {
        try {
            leftHandActiveDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }
    
    private void FireRightHandActiveDidChange(bool value) {
        try {
            rightHandActiveDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }
    
    private void FireAvatarMeshActiveDidChange(bool value) {
        try {
            avatarMeshActiveDidChange?.Invoke(this, value);
        } catch (System.Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
    }
    
    protected override int WriteLength(StreamContext context) {
        int length = 0;
        if (context.fullModel) {
            FlattenCache();
            length += WriteStream.WriteVarint32Length((uint)PropertyID.DeviceType, (uint) _deviceType);
            length += WriteStream.WriteStringLength((uint)PropertyID.DeviceModel, _deviceModel);
            length += WriteStream.WriteVarint32Length((uint)PropertyID.HeadActive, _headActive ? 1u : 0u);
            length += WriteStream.WriteVarint32Length((uint)PropertyID.LeftHandActive, _leftHandActive ? 1u : 0u);
            length += WriteStream.WriteVarint32Length((uint)PropertyID.RightHandActive, _rightHandActive ? 1u : 0u);
            length += WriteStream.WriteVarint32Length((uint)PropertyID.AvatarMeshActive, _avatarMeshActive ? 1u : 0u);
        } else if (context.reliableChannel) {
            LocalCacheEntry entry = _cache.localCache;
            if (entry.deviceTypeSet) {
                length += WriteStream.WriteVarint32Length((uint)PropertyID.DeviceType, (uint) entry.deviceType);
            }
            if (entry.deviceModelSet) {
                length += WriteStream.WriteStringLength((uint)PropertyID.DeviceModel, entry.deviceModel);
            }
            if (entry.headActiveSet) {
                length += WriteStream.WriteVarint32Length((uint)PropertyID.HeadActive, entry.headActive ? 1u : 0u);
            }
            if (entry.leftHandActiveSet) {
                length += WriteStream.WriteVarint32Length((uint)PropertyID.LeftHandActive, entry.leftHandActive ? 1u : 0u);
            }
            if (entry.rightHandActiveSet) {
                length += WriteStream.WriteVarint32Length((uint)PropertyID.RightHandActive, entry.rightHandActive ? 1u : 0u);
            }
            if (entry.avatarMeshActiveSet) {
                length += WriteStream.WriteVarint32Length((uint)PropertyID.AvatarMeshActive, entry.avatarMeshActive ? 1u : 0u);
            }
        }
        return length;
    }
    
    protected override void Write(WriteStream stream, StreamContext context) {
        var didWriteProperties = false;
        
        if (context.fullModel) {
            stream.WriteVarint32((uint)PropertyID.DeviceType, (uint) _deviceType);
            stream.WriteString((uint)PropertyID.DeviceModel, _deviceModel);
            stream.WriteVarint32((uint)PropertyID.HeadActive, _headActive ? 1u : 0u);
            stream.WriteVarint32((uint)PropertyID.LeftHandActive, _leftHandActive ? 1u : 0u);
            stream.WriteVarint32((uint)PropertyID.RightHandActive, _rightHandActive ? 1u : 0u);
            stream.WriteVarint32((uint)PropertyID.AvatarMeshActive, _avatarMeshActive ? 1u : 0u);
        } else if (context.reliableChannel) {
            LocalCacheEntry entry = _cache.localCache;
            if (entry.deviceTypeSet || entry.deviceModelSet || entry.headActiveSet || entry.leftHandActiveSet || entry.rightHandActiveSet || entry.avatarMeshActiveSet) {
                _cache.PushLocalCacheToInflight(context.updateID);
                ClearCacheOnStreamCallback(context);
            }
            if (entry.deviceTypeSet) {
                stream.WriteVarint32((uint)PropertyID.DeviceType, (uint) entry.deviceType);
                didWriteProperties = true;
            }
            if (entry.deviceModelSet) {
                stream.WriteString((uint)PropertyID.DeviceModel, entry.deviceModel);
                didWriteProperties = true;
            }
            if (entry.headActiveSet) {
                stream.WriteVarint32((uint)PropertyID.HeadActive, entry.headActive ? 1u : 0u);
                didWriteProperties = true;
            }
            if (entry.leftHandActiveSet) {
                stream.WriteVarint32((uint)PropertyID.LeftHandActive, entry.leftHandActive ? 1u : 0u);
                didWriteProperties = true;
            }
            if (entry.rightHandActiveSet) {
                stream.WriteVarint32((uint)PropertyID.RightHandActive, entry.rightHandActive ? 1u : 0u);
                didWriteProperties = true;
            }
            if (entry.avatarMeshActiveSet) {
                stream.WriteVarint32((uint)PropertyID.AvatarMeshActive, entry.avatarMeshActive ? 1u : 0u);
                didWriteProperties = true;
            }
            
            if (didWriteProperties) InvalidateReliableLength();
        }
    }
    
    protected override void Read(ReadStream stream, StreamContext context) {
        while (stream.ReadNextPropertyID(out uint propertyID)) {
            switch (propertyID) {
                case (uint)PropertyID.DeviceType: {
                    _deviceType = (Normal.Realtime.RealtimeAvatar.DeviceType) stream.ReadVarint32();
                    break;
                }
                case (uint)PropertyID.DeviceModel: {
                    _deviceModel = stream.ReadString();
                    break;
                }
                case (uint)PropertyID.HeadActive: {
                    bool previousValue = _headActive;
                    _headActive = (stream.ReadVarint32() != 0);
                    bool headActiveExistsInChangeCache = _cache.ValueExistsInCache(entry => entry.headActiveSet);
                    if (!headActiveExistsInChangeCache && _headActive != previousValue) {
                        FireHeadActiveDidChange(_headActive);
                    }
                    break;
                }
                case (uint)PropertyID.LeftHandActive: {
                    bool previousValue = _leftHandActive;
                    _leftHandActive = (stream.ReadVarint32() != 0);
                    bool leftHandActiveExistsInChangeCache = _cache.ValueExistsInCache(entry => entry.leftHandActiveSet);
                    if (!leftHandActiveExistsInChangeCache && _leftHandActive != previousValue) {
                        FireLeftHandActiveDidChange(_leftHandActive);
                    }
                    break;
                }
                case (uint)PropertyID.RightHandActive: {
                    bool previousValue = _rightHandActive;
                    _rightHandActive = (stream.ReadVarint32() != 0);
                    bool rightHandActiveExistsInChangeCache = _cache.ValueExistsInCache(entry => entry.rightHandActiveSet);
                    if (!rightHandActiveExistsInChangeCache && _rightHandActive != previousValue) {
                        FireRightHandActiveDidChange(_rightHandActive);
                    }
                    break;
                }
                case (uint)PropertyID.AvatarMeshActive: {
                    bool previousValue = _avatarMeshActive;
                    _avatarMeshActive = (stream.ReadVarint32() != 0);
                    bool avatarMeshActiveExistsInChangeCache = _cache.ValueExistsInCache(entry => entry.avatarMeshActiveSet);
                    if (!avatarMeshActiveExistsInChangeCache && _avatarMeshActive != previousValue) {
                        FireAvatarMeshActiveDidChange(_avatarMeshActive);
                    }
                    break;
                }
                default: {
                    stream.SkipProperty();
                    break;
                }
            }
        }
    }
    
    #region Cache Operations
    
    private StreamEventDispatcher _streamEventDispatcher;
    
    private void FlattenCache() {
        _deviceType = deviceType;
        _deviceModel = deviceModel;
        _headActive = headActive;
        _leftHandActive = leftHandActive;
        _rightHandActive = rightHandActive;
        _avatarMeshActive = avatarMeshActive;
        _cache.Clear();
    }
    
    private void ClearCache(uint updateID) {
        _cache.RemoveUpdateFromInflight(updateID);
    }
    
    private void ClearCacheOnStreamCallback(StreamContext context) {
        if (_streamEventDispatcher != context.dispatcher) {
            UnsubscribeClearCacheCallback(); // unsub from previous dispatcher
        }
        _streamEventDispatcher = context.dispatcher;
        _streamEventDispatcher.AddStreamCallback(context.updateID, ClearCache);
    }
    
    private void UnsubscribeClearCacheCallback() {
        if (_streamEventDispatcher != null) {
            _streamEventDispatcher.RemoveStreamCallback(ClearCache);
            _streamEventDispatcher = null;
        }
    }
    
    #endregion
}
/* ----- End Normal Autogenerated Code ----- */
