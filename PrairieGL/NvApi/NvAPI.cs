///TODO: NvApi not worth the effort.
///
/// Pfft use these lines in exe (Won't work importing reference to open cl library).
/// By calling OpenCL GetPlatformIDs from the main exe code it tells the NVidia driver to use the NVIDIA gpu card
/*
[DllImport("opencl.dll", EntryPoint = "clGetPlatformIDs", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
static extern CLResult GetPlatformIDs(int num_entries, [In, Out] IntPtr[] platforms, out int num_platforms);

GetPlatformIDs(0, null, out int num_platforms);
*/

/*
 https://github.com/falahati/NvAPIWrapper
https://github.com/bo3b/3Dmigoto/blob/master/nvapi.h
https://docs.nvidia.com/gameworks/content/gameworkslibrary/coresdk/nvapi/group__oglapi.html
https://docs.nvidia.com/gameworks/content/gameworkslibrary/coresdk/nvapi/nvapi__lite__common_8h.html
https://docs.nvidia.com/gameworks/content/gameworkslibrary/coresdk/nvapi/group__drsapi.html#gafda168c3294158a7c7d3b3f642f9180e
https://developer.download.nvidia.com/devzone/devcenter/gamegraphics/files/OptimusRenderingPolicies.pdf

 */


//using PrairieGL.OpenGL;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Runtime.InteropServices;
//using System.Text;
//using System.Threading.Tasks;
//using NvAPIWrapper;
//using NvAPIWrapper.Native.DRS.Structures;
//using NvAPIWrapper.DRS;

///*
// N v U 3 2 = uint
// N v U 8 = byte
//*/

//namespace PrairieGL.NvApi
//{
//    public class NvAPI
//    {
//    //    [DllImport("nvapi64.dll", EntryPoint = "nvapi_QueryInterface", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
//    //    public static extern IntPtr NvAPI_QueryInterface(NvApiFunctionMagicNumbers device);



//    //    //static readonly uint NVDRS_SETTING_VER = MAKE_NVAPI_VERSION(typeof(NVDRS_SETTING), 1);

//    //    public delegate NvAPI_Status InitializeDelegate();
//    //    public delegate NvAPI_Status DRS_CreateSessionDelegate(out NvDRSSessionHandle hSession);
//    //    public delegate NvAPI_Status DRS_DestroySessionDelegate(NvDRSSessionHandle hSession);
//    //    public delegate NvAPI_Status DRS_LoadSettingsDelegate(NvDRSSessionHandle hSession);
//    //    public delegate NvAPI_Status DRS_GetBaseProfileDelegate(NvDRSSessionHandle hSession, out NvDRSProfileHandle phProfile);
//    //    public delegate NvAPI_Status DRS_SetSettingDelegate(NvDRSSessionHandle hSession, NvDRSProfileHandle hProfile, NVDRS_SETTING pSetting);
//    //    public delegate NvAPI_Status DRS_SaveSettingsDelegate(NvDRSSessionHandle hSession);


//    //    static NvAPI_Status Initialize()
//    //    {
//    //        IntPtr ptr = NvAPI_QueryInterface(NvApiFunctionMagicNumbers.NvAPI_Initialize);
//    //        InitializeDelegate dlg = (InitializeDelegate)Marshal.GetDelegateForFunctionPointer(ptr, typeof(InitializeDelegate));
//    //        return dlg();
//    //    }
//    //    /// <summary>
//    //    /// This API allocates memory and initializes the session.
//    //    /// </summary>
//    //    /// <param name="hSession">Return pointer to the session handle.</param>
//    //    /// <returns>
//    //    /// NVAPI_OK SUCCESS
//    //    /// NVAPI_ERROR For miscellaneous errors.
//    //    /// </returns>
//    //    static NvAPI_Status DRS_CreateSession(out NvDRSSessionHandle hSession)
//    //    {
//    //        IntPtr ptr = NvAPI_QueryInterface(NvApiFunctionMagicNumbers.NvAPI_DRS_CreateSession); //"NvAPI_DRS_CreateSession");
//    //        DRS_CreateSessionDelegate dlg = (DRS_CreateSessionDelegate)Marshal.GetDelegateForFunctionPointer(ptr, typeof(DRS_CreateSessionDelegate));
//    //        return dlg(out hSession);
//    //}

//    ///// <summary>
//    ///// This API frees the allocation: cleanup of NvDrsSession.
//    ///// </summary>
//    ///// <param name="hSession">Input to the session handle.</param>
//    ///// <returns>
//    ///// NVAPI_OK	SUCCESS
//    ///// NVAPI_ERROR For miscellaneous errors.
//    ///// </returns>
//    //static NvAPI_Status DRS_DestroySession(NvDRSSessionHandle hSession)
//    //{
//    //    IntPtr ptr = NvAPI_QueryInterface(NvApiFunctionMagicNumbers.NvAPI_DRS_DestroySession); //"NvAPI_DRS_DestroySession");
//    //        DRS_DestroySessionDelegate dlg = (DRS_DestroySessionDelegate)Marshal.GetDelegateForFunctionPointer(ptr, typeof(DRS_DestroySessionDelegate));
//    //        return dlg(hSession);
//    //}

//    ///// <summary>
//    ///// This API loads and parses the settings data.
//    ///// </summary>
//    ///// <param name="hSession">Input to the session handle.</param>
//    ///// <returns>
//    ///// NVAPI_OK SUCCESS
//    ///// NVAPI_ERROR For miscellaneous errors.
//    ///// </returns>
//    //static NvAPI_Status DRS_LoadSettings(NvDRSSessionHandle hSession)
//    //    {
//    //    IntPtr ptr = NvAPI_QueryInterface(NvApiFunctionMagicNumbers.NvAPI_DRS_LoadSettings); //"NvAPI_DRS_LoadSettings");
//    //        DRS_LoadSettingsDelegate dlg = (DRS_LoadSettingsDelegate)Marshal.GetDelegateForFunctionPointer(ptr, typeof(DRS_LoadSettingsDelegate));
//    //        return dlg(hSession.Handle);
//    //}

//    ///// <summary>
//    ///// Returns the handle to the current global profile.
//    ///// </summary>
//    ///// <param name="hSession">Input to the session handle</param>
//    ///// <param name="phProfile">Returns Base profile handle.</param>
//    ///// <returns></returns>
//    //static NvAPI_Status DRS_GetBaseProfile(NvDRSSessionHandle hSession, out NvDRSProfileHandle phProfile)
//    //    {
//    //    IntPtr ptr = NvAPI_QueryInterface(NvApiFunctionMagicNumbers.NvAPI_DRS_GetBaseProfile); //"NvAPI_DRS_GetBaseProfile");
//    //        DRS_GetBaseProfileDelegate dlg = (DRS_GetBaseProfileDelegate)Marshal.GetDelegateForFunctionPointer(ptr, typeof(DRS_GetBaseProfileDelegate));
//    //        return dlg(hSession.Handle, out phProfile);
//    //}

//    //static NvAPI_Status DRS_SetSetting(NvDRSSessionHandle hSession, NvDRSProfileHandle hProfile, NVDRS_SETTING pSetting)
//    //    {
//    //    IntPtr ptr = NvAPI_QueryInterface(NvApiFunctionMagicNumbers.NvAPI_DRS_SetSetting); //"NvAPI_DRS_SetSetting");
//    //        DRS_SetSettingDelegate dlg = (DRS_SetSettingDelegate)Marshal.GetDelegateForFunctionPointer(ptr, typeof(DRS_SetSettingDelegate));
//    //        return dlg(hSession.Handle, hProfile.Handle, pSetting);
//    //}

//    //static NvAPI_Status DRS_SaveSettings(NvDRSSessionHandle hSession)
//    //    {
//    //    IntPtr ptr = NvAPI_QueryInterface(NvApiFunctionMagicNumbers.NvAPI_DRS_SaveSettings); //"NvAPI_DRS_SaveSettings");
//    //        DRS_SaveSettingsDelegate dlg = (DRS_SaveSettingsDelegate)Marshal.GetDelegateForFunctionPointer(ptr, typeof(DRS_SaveSettingsDelegate));
//    //        return dlg(hSession.Handle);
//    //}


//    //public struct NvDRSSessionHandle
//    //    {
//    //        public IntPtr Handle;

//    //        public static implicit operator NvDRSSessionHandle(IntPtr from)
//    //        {
//    //            NvDRSSessionHandle to = new NvDRSSessionHandle();
//    //            to.Handle = from;
//    //            return to;
//    //        }

//    //        public static implicit operator IntPtr(NvDRSSessionHandle from)
//    //        {
//    //            return from.Handle;
//    //        }
//    //    }

//    //    public struct NvDRSProfileHandle
//    //    {
//    //        public IntPtr Handle;

//    //        public static implicit operator NvDRSProfileHandle(IntPtr from)
//    //        {
//    //            NvDRSProfileHandle to = new NvDRSProfileHandle();
//    //            to.Handle = from;
//    //            return to;
//    //        }

//    //        public static implicit operator IntPtr(NvDRSProfileHandle from)
//    //        {
//    //            return from.Handle;
//    //        }
//    //    }

//    //    //public struct NVDRS_BINARY_SETTING
//    //    //{
//    //    //    public const int NVAPI_BINARY_DATA_MAX = 4096;
//    //    //    public uint valueLength;               //!< valueLength should always be in number of bytes.
//    //    //    public byte[] valueData; // [NVAPI_BINARY_DATA_MAX];
//    //    //}
//    //    [StructLayout(LayoutKind.Sequential, Pack = 8, CharSet = CharSet.Unicode)]
//    //    public struct NVDRS_SETTING
//    //    {
//    //        public void  MAKE_NVAPI_VERSION(int ver) { version = (uint)(Size /*Marshal.SizeOf(this)*/ | ((ver) << 16)); }

//    //        internal static readonly int Size = (2048*2) + (4100) + (8*4); // (int)(Marshal.SizeOf(typeof(NVDRS_SETTING)) | (1 << 16));
//    //        public const int UnicodeStringLength = 2048;
//    //        private const int FullStructureSize = 4100;

//    //        internal uint version;
//    //        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = UnicodeStringLength)]
//    //        internal string settingName;
//    //        internal ESetting settingId;
//    //        internal NVDRS_SETTING_TYPE settingType;
//    //        internal NVDRS_SETTING_LOCATION settingLocation;
//    //        internal uint isCurrentPredefined;
//    //        internal uint isPredefinedValid;
//    //        internal byte[] u32PredefinedValue;
//    //        internal byte[] u32CurrentValue;

//    //        public void SetPredefinedValue(uint value)
//    //        {
//    //            u32PredefinedValue = new byte[FullStructureSize];
//    //            var arrayLengthBytes = BitConverter.GetBytes(value);
//    //            Array.Copy(arrayLengthBytes, 0, u32PredefinedValue, 0, arrayLengthBytes.Length);
//    //        }
//    //        public void SetCurrentValue(uint value)
//    //        {
//    //            u32CurrentValue = new byte[FullStructureSize];
//    //            var arrayLengthBytes = BitConverter.GetBytes(value);
//    //            Array.Copy(arrayLengthBytes, 0, u32CurrentValue, 0, arrayLengthBytes.Length);
//    //        }

//    //        //internal const int Size = (7 * 4) + (2048 * 2);
//    //        //const int NVAPI_UNICODE_STRING_MAX = 2048;

//    //        //public uint version;                //!< Structure Version
//    //        //public ushort[/*NVAPI_UNICODE_STRING_MAX*/] settingName;            //!< String name of setting
//    //        //public ESetting settingId;              //!< 32 bit setting Id
//    //        //public NVDRS_SETTING_TYPE settingType;            //!< Type of setting value.  
//    //        //public NVDRS_SETTING_LOCATION settingLocation;        //!< Describes where the value in CurrentValue comes from. 
//    //        //public uint isCurrentPredefined;    //!< It is different than 0 if the currentValue is a predefined Value, 
//    //        //                              //!< 0 if the currentValue is a user value. 
//    //        //public uint isPredefinedValid;      //!< It is different than 0 if the PredefinedValue union contains a valid value. 

//    //        ////public uint u32PredefinedValue;
//    //        //public uint u32CurrentValue;


//    //        ////        union                                              //!< Setting can hold either DWORD or Binary value or string. Not mixed types.
//    //        //// {
//    //        ////     NvU32 u32PredefinedValue;    //!< Accessing default DWORD value of this setting.
//    //        ////        NVDRS_BINARY_SETTING binaryPredefinedValue; //!< Accessing default Binary value of this setting.
//    //        ////                                                    //!< Must be allocated by caller with valueLength specifying buffer size, 
//    //        ////                                                    //!< or only valueLength will be filled in.
//    //        ////        NvAPI_UnicodeString wszPredefinedValue;    //!< Accessing default unicode string value of this setting.
//    //        ////    };
//    //        ////    union                                              //!< Setting can hold either DWORD or Binary value or string. Not mixed types.
//    //        //// {
//    //        ////     NvU32 u32CurrentValue;    //!< Accessing current DWORD value of this setting.
//    //        ////    NVDRS_BINARY_SETTING binaryCurrentValue; //!< Accessing current Binary value of this setting.
//    //        ////                                             //!< Must be allocated by caller with valueLength specifying buffer size, 
//    //        ////                                             //!< or only valueLength will be filled in.
//    //        ////    NvAPI_UnicodeString wszCurrentValue;    //!< Accessing current unicode string value of this setting.
//    //        ////};
//    //    }

//public static NvAPI_Status SetupNVidiaProfile(bool ForceIntegrated = false)
//        {

//            NvAPI_Status status;
//            // (0) Initialize NVAPI. This must be done first of all
//            NvAPIWrapper.NVIDIA.Initialize();
//            //if (status !=  NvAPI_Status.NVAPI_OK)
//            //    return status;
//            // (1) Create the session handle to access driver settings
//            DRSSessionHandle hSession= NvAPIWrapper.Native.DRSApi.CreateSession();
//            //if (status != NvAPI_Status.NVAPI_OK)
//            //{
//            //    NvAPIWrapper.Native.DRSApi.vDestroySession(hSession);
//            //    return status;
//            //}
//            // (2) load all the system settings into the session
//            NvAPIWrapper.Native.DRSApi.LoadSettings(hSession);
//            //if (status != NvAPI_Status.NVAPI_OK)
//            //{
//            //    NvAPIWrapper.Native.DRSApi.DestroySession(hSession);
//            //    return status;
//            //}
//            // (3) Obtain the Base profile. Any setting needs to be inside
//            // a profile, putting a setting on the Base Profile enforces it
//            // for all the processes on the system
//            DRSProfileHandle hProfile = NvAPIWrapper.Native.DRSApi.GetBaseProfile(hSession);
//            //if (status != NvAPI_Status.NVAPI_OK)
//            //{
//            //    NvAPIWrapper.Native.DRSApi.DestroySession(hSession);
//            //    return status;
//            //}
//            //hSession.
//            //DriverSettingsProfile.
//            NvAPIWrapper.Native.DRSApi.

//            ProfileSetting drsSetting1 = ProfileSetting.
//            drsSetting1.SettingId = ESetting.SHIM_MCCOMPAT_ID;
//            drsSetting1.settingType = NVDRS_SETTING_TYPE.NVDRS_DWORD_TYPE;

//            DRSApplicationV1 drsSetting2 = new DRSApplicationV1();
//            drsSetting2.settingId = ESetting.SHIM_RENDERING_MODE_ID;
//            drsSetting2.settingType = NVDRS_SETTING_TYPE.NVDRS_DWORD_TYPE;

//            DRSApplicationV1 drsSetting3 = new DRSApplicationV1();
//            drsSetting3.settingId = ESetting.SHIM_RENDERING_OPTIONS_ID;
//            drsSetting3.settingType = NVDRS_SETTING_TYPE.NVDRS_DWORD_TYPE;

//            if (ForceIntegrated)
//            {
//                drsSetting1.SetCurrentValue((uint)EValues_SHIM_MCCOMPAT.SHIM_MCCOMPAT_INTEGRATED);
//                drsSetting2.SetCurrentValue((uint)EValues_SHIM_RENDERING_MODE.SHIM_RENDERING_MODE_INTEGRATED);
//                drsSetting3.SetCurrentValue((uint)EValues_SHIM_RENDERING_OPTIONS.SHIM_RENDERING_OPTIONS_DEFAULT_RENDERING_MODE | (uint)EValues_SHIM_RENDERING_OPTIONS.SHIM_RENDERING_OPTIONS_IGPU_TRANSCODING);
//            }
//            else
//            {
//                drsSetting1.SetCurrentValue((uint)EValues_SHIM_MCCOMPAT.SHIM_MCCOMPAT_ENABLE);
//                drsSetting2.SetCurrentValue((uint)EValues_SHIM_RENDERING_MODE.SHIM_RENDERING_MODE_ENABLE);
//                drsSetting3.SetCurrentValue((uint)EValues_SHIM_RENDERING_OPTIONS.SHIM_RENDERING_OPTIONS_DEFAULT_RENDERING_MODE);
//            }

//            drsSetting1.SetPredefinedValue(0);
//            drsSetting2.SetPredefinedValue(0);
//            drsSetting3.SetPredefinedValue(0);

//            drsSetting1.MAKE_NVAPI_VERSION(1);  //NVDRS_SETTING_VER;
//            drsSetting2.MAKE_NVAPI_VERSION(1);  //NVDRS_SETTING_VER;
//            drsSetting3.MAKE_NVAPI_VERSION(1);  //NVDRS_SETTING_VER;


//            status = NvAPIWrapper.Native.DRSApi.SetSetting(hSession, hProfile, drsSetting1);
//            if (status != NvAPI_Status.NVAPI_OK)
//            {
//                NvAPIWrapper.Native.DRSApi.DestroySession(hSession);
//                return status;
//            }

//            status = NvAPIWrapper.Native.DRSApi.SetSetting(hSession, hProfile, drsSetting2);
//            if (status != NvAPI_Status.NVAPI_OK)
//            {
//                NvAPIWrapper.Native.DRSApi.DestroySession(hSession);
//                return status;
//            }

//            status = NvAPIWrapper.Native.DRSApi.SetSetting(hSession, hProfile, drsSetting3);
//            if (status != NvAPI_Status.NVAPI_OK)
//            {
//                NvAPIWrapper.Native.DRSApi.DestroySession(hSession);
//                return status;
//            }

//            // (5) Now we apply (or save) our changes to the system
//            status = NvAPIWrapper.Native.DRSApi.SaveSettings(hSession);
//            if (status != NvAPI_Status.NVAPI_OK)
//            {
//                NvAPIWrapper.Native.DRSApi.DestroySession(hSession);
//                return status;
//            }

//            // (6) We clean up. This is analogous to doing a free()
//            NvAPIWrapper.Native.DRSApi.DestroySession(hSession);

//            return status;
//        }

//    }
//}
