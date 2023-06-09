﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrairieGL.NvApi
{
    public enum NvApiFunctionMagicNumbers : uint
    {

        NvAPI_CreateDisplayFromUnAttachedDisplay = 0x63F9799E,
        NvAPI_D3D_BeginResourceRendering = 0x91123D6A,
        NvAPI_D3D_ConfigureAnsel = 0x341C6C7F,
        NvAPI_D3D_CreateLateLatchObject = 0x2DB27D09,
        NvAPI_D3D_EndResourceRendering = 0x37E7191C,
        NvAPI_D3D_GetCurrentSLIState = 0x4B708B54,
        NvAPI_D3D_GetObjectHandleForResource = 0xFCEAC864,
        NvAPI_D3D_ImplicitSLIControl = 0x2AEDE111,
        NvAPI_D3D_InitializeSMPAssist = 0x42763D0C,
        NvAPI_D3D_IsGSyncActive = 0xE942B0FF,
        NvAPI_D3D_IsGSyncCapable = 0x9C1EED78,
        NvAPI_D3D_QueryLateLatchSupport = 0x8CECA0EC,
        NvAPI_D3D_QueryModifiedWSupport = 0xCBF9F4F5,
        NvAPI_D3D_QueryMultiViewSupport = 0xB6E0A41C,
        NvAPI_D3D_QuerySinglePassStereoSupport = 0x6F5F0A6D,
        NvAPI_D3D_QuerySMPAssistSupport = 0xC57921DE,
        NvAPI_D3D_RegisterDevice = 0x8C02C4D0,
        NvAPI_D3D_SetFPSIndicatorState = 0xA776E8DB,
        NvAPI_D3D_SetModifiedWMode = 0x6EA4BF4,
        NvAPI_D3D_SetMultiViewMode = 0x8285C8DA,
        NvAPI_D3D_SetResourceHint = 0x6C0ED98C,
        NvAPI_D3D_SetSinglePassStereoMode = 0xA39E6E6E,
        NvAPI_D3D10_SetDepthBoundsTest = 0x4EADF5D2,
        NvAPI_D3D11_AliasMSAATexture2DAsNonMSAA = 0xF1C54FC9,
        NvAPI_D3D11_BeginUAVOverlap = 0x65B93CA8,
        NvAPI_D3D11_BeginUAVOverlapEx = 0xBA08208A,
        NvAPI_D3D11_CopyTileMappings = 0xC09EE6BC,
        NvAPI_D3D11_CreateDevice = 0x6A16D3A0,
        NvAPI_D3D11_CreateDeviceAndSwapChain = 0xBB939EE5,
        NvAPI_D3D11_CreateDomainShaderEx = 0xA0D7180D,
        NvAPI_D3D11_CreateFastGeometryShader = 0x525D43BE,
        NvAPI_D3D11_CreateFastGeometryShaderExplicit = 0x71AB7C9C,
        NvAPI_D3D11_CreateGeometryShaderEx_2 = 0x99ED5C1C,
        NvAPI_D3D11_CreateHullShaderEx = 0xB53CAB00,
        NvAPI_D3D11_CreateMultiGPUDevice = 0xBDB20007,
        NvAPI_D3D11_CreatePixelShaderEx_2 = 0x4162822B,
        NvAPI_D3D11_CreateRasterizerState = 0xDB8D28AF,
        NvAPI_D3D11_CreateShadingRateResourceView = 0x99CA2DFF,
        NvAPI_D3D11_CreateTiledTexture2DArray = 0x7886981A,
        NvAPI_D3D11_CreateVertexShaderEx = 0xBEAA0B2,
        NvAPI_D3D11_EndUAVOverlap = 0x2216A357,
        NvAPI_D3D11_IsNvShaderExtnOpCodeSupported = 0x5F68DA40,
        NvAPI_D3D11_MultiDrawIndexedInstancedIndirect = 0x59E890F9,
        NvAPI_D3D11_MultiDrawInstancedIndirect = 0xD4E26BBF,
        NvAPI_D3D11_MultiGPU_GetCaps = 0xD2D25687,
        NvAPI_D3D11_MultiGPU_Init = 0x17BE49E,
        NvAPI_D3D11_RSGetPixelShadingRateSampleOrder = 0x92442A1,
        NvAPI_D3D11_RSSetExclusiveScissorRects = 0xAE4D73EF,
        NvAPI_D3D11_RSSetPixelShadingRateSampleOrder = 0xA942373A,
        NvAPI_D3D11_RSSetShadingRateResourceView = 0x1B0C2F83,
        NvAPI_D3D11_RSSetViewportsPixelShadingRates = 0x34F7938F,
        NvAPI_D3D11_SetDepthBoundsTest = 0x7AAF7A04,
        NvAPI_D3D11_SetNvShaderExtnSlot = 0x8E90BB9F,
        NvAPI_D3D11_SetNvShaderExtnSlotLocalThread = 0xE6482A0,
        NvAPI_D3D11_TiledResourceBarrier = 0xD6839099,
        NvAPI_D3D11_TiledTexture2DArrayGetDesc = 0xF1A2B9D5,
        NvAPI_D3D11_UpdateTileMappings = 0x9A06EA07,
        NvAPI_D3D12_CopyTileMappings = 0x47F78194,
        NvAPI_D3D12_CreateComputePipelineState = 0x2762DEAC,
        NvAPI_D3D12_CreateGraphicsPipelineState = 0x2FC28856,
        NvAPI_D3D12_CreateHeap = 0x5CB397CF,
        NvAPI_D3D12_CreateReservedResource = 0x2C85F101,
        NvAPI_D3D12_IsNvShaderExtnOpCodeSupported = 0x3DFACEC8,
        NvAPI_D3D12_Mosaic_GetCompanionAllocations = 0xA46022C7,
        NvAPI_D3D12_Mosaic_GetViewportAndGpuPartitions = 0xB092B818,
        NvAPI_D3D12_QueryModifiedWSupport = 0x51235248,
        NvAPI_D3D12_QuerySinglePassStereoSupport = 0x3B03791B,
        NvAPI_D3D12_ReservedResourceGetDesc = 0x9AA2AABB,
        NvAPI_D3D12_ResourceAliasingBarrier = 0xB942BAB7,
        NvAPI_D3D12_SetDepthBoundsTestValues = 0xB9333FE9,
        NvAPI_D3D12_SetModifiedWMode = 0xE1FDABA7,
        NvAPI_D3D12_SetSinglePassStereoMode = 0x83556D87,
        NvAPI_D3D12_UpdateTileMappings = 0xC6017A7D,
        NvAPI_D3D12_UseDriverHeapPriorities = 0xF0D978A8,
        NvAPI_D3D1x_CreateSwapChain = 0x1BC21B66,
        NvAPI_D3D1x_DisableShaderDiskCache = 0xD0CBCA7D,
        NvAPI_D3D1x_GetGraphicsCapabilities = 0x52B1499A,
        NvAPI_D3D9_AliasSurfaceAsTexture = 0xE5CEAE41,
        NvAPI_D3D9_ClearRT = 0x332D3942,
        NvAPI_D3D9_CreateSwapChain = 0x1A131E09,
        NvAPI_D3D9_GetSurfaceHandle = 0xF2DD3F2,
        NvAPI_D3D9_RegisterResource = 0xA064BDFC,
        NvAPI_D3D9_StretchRectEx = 0x22DE03AA,
        NvAPI_D3D9_UnregisterResource = 0xBB2B17AA,
        NvAPI_D3D9_VideoSetStereoInfo = 0xB852F4DB,
        NvAPI_DisableHWCursor = 0xAB163097,
        NvAPI_Disp_ColorControl = 0x92F9D80D,
        NvAPI_DISP_DeleteCustomDisplay = 0x552E5B9B,
        NvAPI_DISP_EnumCustomDisplay = 0xA2072D59,
        NvAPI_DISP_GetAssociatedUnAttachedNvidiaDisplayHandle = 0xA70503B2,
        NvAPI_DISP_GetDisplayConfig = 0x11ABCCF8,
        NvAPI_DISP_GetDisplayIdByDisplayName = 0xAE457190,
        NvAPI_DISP_GetGDIPrimaryDisplayId = 0x1E9D8A31,
        NvAPI_Disp_GetHdrCapabilities = 0x84F2A8DF,
        NvAPI_DISP_GetMonitorCapabilities = 0x3B05C7E1,
        NvAPI_DISP_GetMonitorColorCapabilities = 0x6AE4CFB5,
        NvAPI_DISP_GetTiming = 0x175167E9,
        NvAPI_Disp_HdrColorControl = 0x351DA224,
        NvAPI_Disp_InfoFrameControl = 0x6067AF3F,
        NvAPI_DISP_RevertCustomDisplayTrial = 0xCBBD40F0,
        NvAPI_DISP_SaveCustomDisplay = 0x49882876,
        NvAPI_DISP_SetDisplayConfig = 0x5D8CF8DE,
        NvAPI_DISP_TryCustomDisplay = 0x1F7DB630,
        NvAPI_DRS_CreateApplication = 0x4347A9DE,
        NvAPI_DRS_CreateProfile = 0xCC176068,
        NvAPI_DRS_CreateSession = 0x694D52E,
        NvAPI_DRS_DeleteApplication = 0x2C694BC6,
        NvAPI_DRS_DeleteApplicationEx = 0xC5EA85A1,
        NvAPI_DRS_DeleteProfile = 0x17093206,
        NvAPI_DRS_DeleteProfileSetting = 0xE4A26362,
        NvAPI_DRS_DestroySession = 0xDAD9CFF8,
        NvAPI_DRS_EnumApplications = 0x7FA2173A,
        NvAPI_DRS_EnumAvailableSettingIds = 0xF020614A,
        NvAPI_DRS_EnumAvailableSettingValues = 0x2EC39F90,
        NvAPI_DRS_EnumProfiles = 0xBC371EE0,
        NvAPI_DRS_EnumSettings = 0xAE3039DA,
        NvAPI_DRS_FindApplicationByName = 0xEEE566B2,
        NvAPI_DRS_FindProfileByName = 0x7E4A9A0B,
        NvAPI_DRS_GetApplicationInfo = 0xED1F8C69,
        NvAPI_DRS_GetBaseProfile = 0xDA8466A0,
        NvAPI_DRS_GetCurrentGlobalProfile = 0x617BFF9F,
        NvAPI_DRS_GetNumProfiles = 0x1DAE4FBC,
        NvAPI_DRS_GetProfileInfo = 0x61CD6FD6,
        NvAPI_DRS_GetSetting = 0x73BF8338,
        NvAPI_DRS_GetSettingIdFromName = 0xCB7309CD,
        NvAPI_DRS_GetSettingNameFromId = 0xD61CBE6E,
        NvAPI_DRS_LoadSettings = 0x375DBD6B,
        NvAPI_DRS_LoadSettingsFromFile = 0xD3EDE889,
        NvAPI_DRS_RestoreAllDefaults = 0x5927B094,
        NvAPI_DRS_RestoreProfileDefault = 0xFA5F6134,
        NvAPI_DRS_RestoreProfileDefaultSetting = 0x53F0381E,
        NvAPI_DRS_SaveSettings = 0xFCBC7E14,
        NvAPI_DRS_SaveSettingsToFile = 0x2BE25DF8,
        NvAPI_DRS_SetCurrentGlobalProfile = 0x1C89C5DF,
        NvAPI_DRS_SetProfileInfo = 0x16ABD3A9,
        NvAPI_DRS_SetSetting = 0x577DD202,
        NvAPI_EnableCurrentMosaicTopology = 0x74073CC9,
        NvAPI_EnableHWCursor = 0x2863148D,
        NvAPI_EnumLogicalGPUs = 0x48B3EA59,
        NvAPI_EnumNvidiaDisplayHandle = 0x9ABDD40D,
        NvAPI_EnumNvidiaUnAttachedDisplayHandle = 0x20DE9260,
        NvAPI_EnumPhysicalGPUs = 0xE5AC921F,
        NvAPI_EnumTCCPhysicalGPUs = 0xD9930B07,
        NvAPI_GetAssociatedDisplayOutputId = 0xD995937E,
        NvAPI_GetAssociatedNvidiaDisplayHandle = 0x35C29134,
        NvAPI_GetAssociatedNvidiaDisplayName = 0x22A78B05,
        NvAPI_GetCurrentMosaicTopology = 0xF60852BD,
        NvAPI_GetDisplayDriverVersion = 0xF951A4D1,
        NvAPI_GetDisplayPortInfo = 0xC64FF367,
        NvAPI_GetErrorMessage = 0x6C2D048C,
        NvAPI_GetHDMISupportInfo = 0x6AE16EC3,
        NvAPI_GetInterfaceVersionString = 0x1053FA5,
        NvAPI_GetLogicalGPUFromDisplay = 0xEE1370CF,
        NvAPI_GetLogicalGPUFromPhysicalGPU = 0xADD604D1,
        NvAPI_GetPhysicalGPUFromUnAttachedDisplay = 0x5018ED61,
        NvAPI_GetPhysicalGPUsFromDisplay = 0x34EF9506,
        NvAPI_GetPhysicalGPUsFromLogicalGPU = 0xAEA3FA32,
        NvAPI_GetSupportedMosaicTopologies = 0x410B5C25,
        NvAPI_GetSupportedViews = 0x66FB7FC0,
        NvAPI_GetUnAttachedAssociatedDisplayName = 0x4888D790,
        NvAPI_GetVBlankCounter = 0x67B5DB55,
        NvAPI_GetView = 0xD6B99D89,
        NvAPI_GetViewEx = 0xDBBC0AF4,
        NvAPI_GPU_ClientIllumDevicesGetControl = 0x73C01D58,
        NvAPI_GPU_ClientIllumDevicesGetInfo = 0xD4100E58,
        NvAPI_GPU_ClientIllumDevicesSetControl = 0x57024C62,
        NvAPI_GPU_ClientIllumZonesGetControl = 0x3DBF5764,
        NvAPI_GPU_ClientIllumZonesGetInfo = 0x4B81241B,
        NvAPI_GPU_ClientIllumZonesSetControl = 0x197D065E,
        NvAPI_GPU_GetActiveOutputs = 0xE3E89B6F,
        NvAPI_GPU_GetAGPAperture = 0x6E042794,
        NvAPI_GPU_GetAllClockFrequencies = 0xDCB616C3,
        NvAPI_GPU_GetAllDisplayIds = 0x785210A2,
        NvAPI_GPU_GetAllOutputs = 0x7D554F8E,
        NvAPI_GPU_GetBoardInfo = 0x22D54523,
        NvAPI_GPU_GetBusId = 0x1BE0B8E5,
        NvAPI_GPU_GetBusSlotId = 0x2A0A350F,
        NvAPI_GPU_GetBusType = 0x1BB18724,
        NvAPI_GPU_GetConnectedDisplayIds = 0x78DBA2,
        NvAPI_GPU_GetConnectedOutputs = 0x1730BFC9,
        NvAPI_GPU_GetConnectedOutputsWithLidState = 0xCF8CAF39,
        NvAPI_GPU_GetConnectedSLIOutputs = 0x680DE09,
        NvAPI_GPU_GetConnectedSLIOutputsWithLidState = 0x96043CC7,
        NvAPI_GPU_GetCurrentAGPRate = 0xC74925A0,
        NvAPI_GPU_GetCurrentPCIEDownstreamWidth = 0xD048C3B1,
        NvAPI_GPU_GetCurrentPstate = 0x927DA4F6,
        NvAPI_GPU_GetDynamicPstatesInfoEx = 0x60DED2ED,
        NvAPI_GPU_GetECCConfigurationInfo = 0x77A796F3,
        NvAPI_GPU_GetECCErrorInfo = 0xC71F85A6,
        NvAPI_GPU_GetECCStatusInfo = 0xCA1DDAF3,
        NvAPI_GPU_GetEDID = 0x37D32E69,
        NvAPI_GPU_GetFullName = 0xCEEE8E9F,
        NvAPI_GPU_GetGpuCoreCount = 0xC7026A87,
        NvAPI_GPU_GetGPUType = 0xC33BAEB1,
        NvAPI_GPU_GetHDCPSupportStatus = 0xF089EEF5,
        NvAPI_GPU_GetIllumination = 0x9A1B9365,
        NvAPI_GPU_GetIRQ = 0xE4715417,
        NvAPI_GPU_GetMemoryInfo = 0x7F9B368,
        NvAPI_GPU_GetOutputType = 0x40A505E4,
        NvAPI_GPU_GetPCIIdentifiers = 0x2DDFB66E,
        NvAPI_GPU_GetPerfDecreaseInfo = 0x7F7F4600,
        NvAPI_GPU_GetPhysicalFrameBufferSize = 0x46FBEB03,
        NvAPI_GPU_GetPstates20 = 0x6FF81213,
        NvAPI_GPU_GetPstatesInfoEx = 0x843C0256,
        NvAPI_GPU_GetQuadroStatus = 0xE332FA47,
        NvAPI_GPU_GetScanoutCompositionParameter = 0x58FE51E6,
        NvAPI_GPU_GetScanoutConfiguration = 0x6A9F5B63,
        NvAPI_GPU_GetScanoutConfigurationEx = 0xE2E1E6F0,
        NvAPI_GPU_GetScanoutIntensityState = 0xE81CE836,
        NvAPI_GPU_GetScanoutWarpingState = 0x6F5435AF,
        NvAPI_GPU_GetShaderSubPipeCount = 0xBE17923,
        NvAPI_GPU_GetSystemType = 0xBAAABFCC,
        NvAPI_GPU_GetTachReading = 0x5F608315,
        NvAPI_GPU_GetThermalSettings = 0xE3640A56,
        NvAPI_GPU_GetVbiosOEMRevision = 0x2D43FB31,
        NvAPI_GPU_GetVbiosRevision = 0xACC3DA0A,
        NvAPI_GPU_GetVbiosVersionString = 0xA561FD7D,
        NvAPI_GPU_GetVirtualFrameBufferSize = 0x5A04B644,
        NvAPI_GPU_QueryIlluminationSupport = 0xA629DA31,
        NvAPI_GPU_ResetECCErrorInfo = 0xC02EEC20,
        NvAPI_GPU_SetECCConfiguration = 0x1CF639D9,
        NvAPI_GPU_SetEDID = 0xE83D6456,
        NvAPI_GPU_SetIllumination = 0x254A187,
        NvAPI_GPU_SetScanoutCompositionParameter = 0xF898247D,
        NvAPI_GPU_SetScanoutIntensity = 0xA57457A4,
        NvAPI_GPU_SetScanoutWarping = 0xB34BAB4F,
        NvAPI_GPU_ValidateOutputCombination = 0x34C9C2D4,
        NvAPI_GPU_WorkstationFeatureQuery = 0x4537DF,
        NvAPI_GPU_WorkstationFeatureSetup = 0x6C1F3FE4,
        NvAPI_GSync_AdjustSyncDelay = 0x2D11FF51,
        NvAPI_GSync_EnumSyncDevices = 0xD9639601,
        NvAPI_GSync_GetControlParameters = 0x16DE1C6A,
        NvAPI_GSync_GetStatusParameters = 0x70D404EC,
        NvAPI_GSync_GetSyncStatus = 0xF1F5B434,
        NvAPI_GSync_GetTopology = 0x4562BC38,
        NvAPI_GSync_QueryCapabilities = 0x44A3F1D1,
        NvAPI_GSync_SetControlParameters = 0x8BBFF88B,
        NvAPI_GSync_SetSyncStateSettings = 0x60ACDFDD,
        NvAPI_I2CRead = 0x2FDE12C5,
        NvAPI_I2CWrite = 0xE812EB07,
        NvAPI_Mosaic_EnableCurrentTopo = 0x5F1AA66C,
        NvAPI_Mosaic_EnumDisplayGrids = 0xDF2887AF,
        NvAPI_Mosaic_EnumDisplayModes = 0x78DB97D7,
        NvAPI_Mosaic_GetCurrentTopo = 0xEC32944E,
        NvAPI_Mosaic_GetDisplayViewportsByResolution = 0xDC6DC8D3,
        NvAPI_Mosaic_GetOverlapLimits = 0x989685F0,
        NvAPI_Mosaic_GetSupportedTopoInfo = 0xFDB63C81,
        NvAPI_Mosaic_GetTopoGroup = 0xCB89381D,
        NvAPI_Mosaic_SetCurrentTopo = 0x9B542831,
        NvAPI_Mosaic_SetDisplayGrids = 0x4D959A89,
        NvAPI_Mosaic_ValidateDisplayGrids = 0xCF43903D,
        NvAPI_OGL_ExpertModeDefaultsGet = 0xAE921F12,
        NvAPI_OGL_ExpertModeDefaultsSet = 0xB47A657E,
        NvAPI_OGL_ExpertModeGet = 0x22ED9516,
        NvAPI_OGL_ExpertModeSet = 0x3805EF7A,
        NvAPI_SetCurrentMosaicTopology = 0xD54B8989,
        NvAPI_SetDisplayPort = 0xFA13E65A,
        NvAPI_SetRefreshRateOverride = 0x3092AC32,
        NvAPI_SetView = 0x957D7B6,
        NvAPI_SetViewEx = 0x6B89E68,
        NvAPI_Stereo_Activate = 0xF6A1AD68,
        NvAPI_Stereo_CaptureJpegImage = 0x932CB140,
        NvAPI_Stereo_CapturePngImage = 0x8B7E99B5,
        NvAPI_Stereo_CreateConfigurationProfileRegistryKey = 0xBE7692EC,
        NvAPI_Stereo_CreateHandleFromIUnknown = 0xAC7E37F4,
        NvAPI_Stereo_Deactivate = 0x2D68DE96,
        NvAPI_Stereo_Debug_WasLastDrawStereoized = 0xED4416C5,
        NvAPI_Stereo_DecreaseConvergence = 0x4C87E317,
        NvAPI_Stereo_DecreaseSeparation = 0xDA044458,
        NvAPI_Stereo_DeleteConfigurationProfileRegistryKey = 0xF117B834,
        NvAPI_Stereo_DeleteConfigurationProfileValue = 0x49BCEECF,
        NvAPI_Stereo_DestroyHandle = 0x3A153134,
        NvAPI_Stereo_Disable = 0x2EC50C2B,
        NvAPI_Stereo_Enable = 0x239C4545,
        NvAPI_Stereo_GetConvergence = 0x4AB00934,
        NvAPI_Stereo_GetDefaultProfile = 0x624E21C2,
        NvAPI_Stereo_GetEyeSeparation = 0xCE653127,
        NvAPI_Stereo_GetFrustumAdjustMode = 0xE6839B43,
        NvAPI_Stereo_GetSeparation = 0x451F2134,
        NvAPI_Stereo_GetStereoSupport = 0x296C434D,
        NvAPI_Stereo_GetSurfaceCreationMode = 0x36F1C736,
        NvAPI_Stereo_IncreaseConvergence = 0xA17DAABE,
        NvAPI_Stereo_IncreaseSeparation = 0xC9A8ECEC,
        NvAPI_Stereo_InitActivation = 0xC7177702,
        NvAPI_Stereo_IsActivated = 0x1FB0BC30,
        NvAPI_Stereo_IsEnabled = 0x348FF8E1,
        NvAPI_Stereo_IsWindowedModeSupported = 0x40C8ED5E,
        NvAPI_Stereo_ReverseStereoBlitControl = 0x3CD58F89,
        NvAPI_Stereo_SetActiveEye = 0x96EEA9F8,
        NvAPI_Stereo_SetConfigurationProfileValue = 0x24409F48,
        NvAPI_Stereo_SetConvergence = 0x3DD6B54B,
        NvAPI_Stereo_SetDefaultProfile = 0x44F0ECD1,
        NvAPI_Stereo_SetDriverMode = 0x5E8F0BEC,
        NvAPI_Stereo_SetFrustumAdjustMode = 0x7BE27FA2,
        NvAPI_Stereo_SetNotificationMessage = 0x6B9B409E,
        NvAPI_Stereo_SetSeparation = 0x5C069FA3,
        NvAPI_Stereo_SetSurfaceCreationMode = 0xF5DCFCBA,
        NvAPI_Stereo_Trigger_Activation = 0xD6C6CD2,
        NvAPI_SYS_GetChipSetInfo = 0x53DABBCA,
        NvAPI_SYS_GetDisplayIdFromGpuAndOutputId = 0x8F2BAB4,
        NvAPI_SYS_GetDriverAndBranchVersion = 0x2926AAAD,
        NvAPI_SYS_GetGpuAndOutputIdFromDisplayId = 0x112BA1A5,
        NvAPI_SYS_GetLidAndDockInfo = 0xCDA14D8A,
        NvAPI_SYS_GetPhysicalGpuFromDisplayId = 0x9EA74659,
        NvAPI_VIO_Close = 0xD01BD237,
        NvAPI_VIO_EnumDataFormats = 0x221FA8E8,
        NvAPI_VIO_EnumDevices = 0xFD7C5557,
        NvAPI_VIO_EnumSignalFormats = 0xEAD72FE4,
        NvAPI_VIO_GetCapabilities = 0x1DC91303,
        NvAPI_VIO_GetConfig = 0xD34A789B,
        NvAPI_VIO_GetCSC = 0x7B0D72A3,
        NvAPI_VIO_GetGamma = 0x51D53D06,
        NvAPI_VIO_GetPCIInfo = 0xB981D935,
        NvAPI_VIO_GetSyncDelay = 0x462214A9,
        NvAPI_VIO_IsFrameLockModeCompatible = 0x7BF0A94D,
        NvAPI_VIO_IsRunning = 0x96BD040E,
        NvAPI_VIO_Open = 0x44EE4841,
        NvAPI_VIO_QueryTopology = 0x869534E2,
        NvAPI_VIO_SetConfig = 0xE4EEC07,
        NvAPI_VIO_SetCSC = 0xA1EC8D74,
        NvAPI_VIO_SetGamma = 0x964BF452,
        NvAPI_VIO_SetSyncDelay = 0x2697A8D1,
        NvAPI_VIO_Start = 0xCDE8E1A3,
        NvAPI_VIO_Status = 0xE6CE4F1,
        NvAPI_VIO_Stop = 0x6BA2A5D6,
        NvAPI_VIO_SyncFormatDetect = 0x118D48A3,


        // -------------------------------------------------
        // Private Internal NvAPI Functions
        // -------------------------------------------------

        NvAPI_3D_GetProperty = 0x8061A4B1,
        NvAPI_3D_GetPropertyRange = 0x0B85DE27C,
        NvAPI_3D_SetProperty = 0x0C9175E8D,
        NvAPI_AccessDisplayDriverRegistry = 0xF5579360,
        NvAPI_Coproc_GetApplicationCoprocInfo = 0x79232685,
        NvAPI_Coproc_GetCoprocInfoFlagsEx = 0x69A9874D,
        NvAPI_Coproc_GetCoprocStatus = 0x1EFC3957,
        NvAPI_Coproc_NotifyCoprocPowerState = 0x0CADCB956,
        NvAPI_Coproc_SetCoprocInfoFlagsEx = 0x0F4C863AC,
        NvAPI_CreateUnAttachedDisplayFromDisplay = 0xA0C72EE4,
        NvAPI_D3D_CreateQuery = 0x5D19BCA4,
        NvAPI_D3D_DestroyQuery = 0x0C8FF7258,
        NvAPI_D3D_Query_Begin = 0x0E5A9AAE0,
        NvAPI_D3D_Query_End = 0x2AC084FA,
        NvAPI_D3D_Query_GetData = 0x0F8B53C69,
        NvAPI_D3D_Query_GetDataSize = 0x0F2A54796,
        NvAPI_D3D_Query_GetType = 0x4ACEEAF7,
        NvAPI_D3D_RegisterApp = 0x0D44D3C4E,
        NvAPI_D3D10_AliasPrimaryAsTexture = 0x8AAC133D,
        NvAPI_D3D10_BeginShareResource = 0x35233210,
        NvAPI_D3D10_BeginShareResourceEx = 0x0EF303A9D,
        NvAPI_D3D10_CreateDevice = 0x2DE11D61,
        NvAPI_D3D10_CreateDeviceAndSwapChain = 0x5B803DAF,
        NvAPI_D3D10_EndShareResource = 0x0E9C5853,
        NvAPI_D3D10_GetRenderedCursorAsBitmap = 0x0CAC3CE5D,
        NvAPI_D3D10_ProcessCallbacks = 0x0AE9C2019,
        NvAPI_D3D10_SetPrimaryFlipChainCallbacks = 0x73EB9329,
        NvAPI_D3D11_BeginShareResource = 0x121BDC6,
        NvAPI_D3D11_EndShareResource = 0x8FFB8E26,
        NvAPI_D3D1x_BindSwapBarrier = 0x9DE8C729,
        NvAPI_D3D1x_IFR_SetUpTargetBufferToSys = 0x473F7828,
        NvAPI_D3D1x_IFR_TransferRenderTarget = 0x9FBAE4EB,
        NvAPI_D3D1x_JoinSwapGroup = 0x14610CD7,
        NvAPI_D3D1x_Present = 0x3B845A1,
        NvAPI_D3D1x_QueryFrameCount = 0x9152E055,
        NvAPI_D3D1x_QueryMaxSwapGroup = 0x9BB9D68F,
        NvAPI_D3D1x_QuerySwapGroup = 0x407F67AA,
        NvAPI_D3D1x_ResetFrameCount = 0x0FBBB031A,
        NvAPI_D3D9_AliasPrimaryAsTexture = 0x13C7112E,
        NvAPI_D3D9_AliasPrimaryFromDevice = 0x7C20C5BE,
        NvAPI_D3D9_BindSwapBarrier = 0x9C39C246,
        NvAPI_D3D9_CreatePathContextNV = 0x0A342F682,
        NvAPI_D3D9_CreatePathNV = 0x71329DF3,
        NvAPI_D3D9_CreateRenderTarget = 0x0B3827C8,
        NvAPI_D3D9_CreateTexture = 0x0D5E13573,
        NvAPI_D3D9_CreateVideo = 0x89FFD9A3,
        NvAPI_D3D9_CreateVideoBegin = 0x84C9D553,
        NvAPI_D3D9_CreateVideoEnd = 0x0B476BF61,
        NvAPI_D3D9_DeletePathNV = 0x73E0019A,
        NvAPI_D3D9_DestroyPathContextNV = 0x667C2929,
        NvAPI_D3D9_DMA = 0x962B8AF6,
        NvAPI_D3D9_DrawPathNV = 0x13199B3D,
        NvAPI_D3D9_EnableStereo = 0x492A6954,
        NvAPI_D3D9_EnumVideoFeatures = 0x1DB7C52C,
        NvAPI_D3D9_FreeVideo = 0x3111BED1,
        NvAPI_D3D9_GetCurrentRenderTargetHandle = 0x22CAD61,
        NvAPI_D3D9_GetCurrentZBufferHandle = 0x0B380F218,
        NvAPI_D3D9_GetIndexBufferHandle = 0x0FC5A155B,
        NvAPI_D3D9_GetOverlaySurfaceHandles = 0x6800F5FC,
        NvAPI_D3D9_GetSLIInfo = 0x694BFF4D,
        NvAPI_D3D9_GetTextureHandle = 0x0C7985ED5,
        NvAPI_D3D9_GetVertexBufferHandle = 0x72B19155,
        NvAPI_D3D9_GetVideoCapabilities = 0x3D596B93,
        NvAPI_D3D9_GetVideoState = 0x0A4527BF8,
        NvAPI_D3D9_GPUBasedCPUSleep = 0x0D504DDA7,
        NvAPI_D3D9_GpuSyncAcquire = 0x0D00B8317,
        NvAPI_D3D9_GpuSyncEnd = 0x754033F0,
        NvAPI_D3D9_GpuSyncGetHandleSize = 0x80C9FD3B,
        NvAPI_D3D9_GpuSyncInit = 0x6D6FDAD4,
        NvAPI_D3D9_GpuSyncMapIndexBuffer = 0x12EE68F2,
        NvAPI_D3D9_GpuSyncMapSurfaceBuffer = 0x2AB714AB,
        NvAPI_D3D9_GpuSyncMapTexBuffer = 0x0CDE4A28A,
        NvAPI_D3D9_GpuSyncMapVertexBuffer = 0x0DBC803EC,
        NvAPI_D3D9_GpuSyncRelease = 0x3D7A86BB,
        NvAPI_D3D9_IFR_SetUpTargetBufferToNV12BLVideoSurface = 0x0CFC92C15,
        NvAPI_D3D9_IFR_SetUpTargetBufferToSys = 0x55255D05,
        NvAPI_D3D9_IFR_TransferRenderTarget = 0x0AB7C2DC,
        NvAPI_D3D9_IFR_TransferRenderTargetToNV12BLVideoSurface = 0x5FE72F64,
        NvAPI_D3D9_JoinSwapGroup = 0x7D44BB54,
        NvAPI_D3D9_Lock = 0x6317345C,
        NvAPI_D3D9_NVFBC_GetStatus = 0x0bd3eb475,
        NvAPI_D3D9_PathClearDepthNV = 0x157E45C4,
        NvAPI_D3D9_PathDepthNV = 0x0FCB16330,
        NvAPI_D3D9_PathEnableColorWriteNV = 0x3E2804A2,
        NvAPI_D3D9_PathEnableDepthTestNV = 0x0E99BA7F3,
        NvAPI_D3D9_PathMatrixNV = 0x0D2F6C499,
        NvAPI_D3D9_PathParameterfNV = 0x0F7FF00C1,
        NvAPI_D3D9_PathParameteriNV = 0x0FC31236C,
        NvAPI_D3D9_PathVerticesNV = 0x0C23DF926,
        NvAPI_D3D9_Present = 0x5650BEB,
        NvAPI_D3D9_PresentSurfaceToDesktop = 0x0F7029C5,
        NvAPI_D3D9_PresentVideo = 0x5CF7F862,
        NvAPI_D3D9_QueryAAOverrideMode = 0x0DDF5643C,
        NvAPI_D3D9_QueryFrameCount = 0x9083E53A,
        NvAPI_D3D9_QueryMaxSwapGroup = 0x5995410D,
        NvAPI_D3D9_QuerySwapGroup = 0x0EBA4D232,
        NvAPI_D3D9_QueryVideoInfo = 0x1E6634B3,
        NvAPI_D3D9_ResetFrameCount = 0x0FA6A0675,
        NvAPI_D3D9_SetGamutData = 0x2BBDA32E,
        NvAPI_D3D9_SetPitchSurfaceCreation = 0x18CDF365,
        NvAPI_D3D9_SetResourceHint = 0x905F5C27,
        NvAPI_D3D9_SetSLIMode = 0x0BFDC062C,
        NvAPI_D3D9_SetSurfaceCreationLayout = 0x5609B86A,
        NvAPI_D3D9_SetVideoState = 0x0BD4BC56F,
        NvAPI_D3D9_StretchRect = 0x0AEAECD41,
        NvAPI_D3D9_Unlock = 0x0C182027E,
        NvAPI_D3D9_VideoSurfaceEncryptionControl = 0x9D2509EF,
        NvAPI_DeleteCustomDisplay = 0x0E7CB998D,
        NvAPI_DeleteUnderscanConfig = 0x0F98854C8,
        NvAPI_Disp_DpAuxChannelControl = 0x8EB56969,
        NvAPI_DISP_EnumHDMIStereoModes = 0x0D2CCF5D6,
        NvAPI_DISP_GetDisplayBlankingState = 0x63E5D8DB,
        NvAPI_DISP_GetHCloneTopology = 0x47BAD137,
        NvAPI_DISP_GetVirtualModeData = 0x3230D69A,
        NvAPI_DISP_OverrideDisplayModeList = 0x291BFF2,
        NvAPI_DISP_SetDisplayBlankingState = 0x1E17E29B,
        NvAPI_DISP_SetHCloneTopology = 0x61041C24,
        NvAPI_DISP_ValidateHCloneTopology = 0x5F4C2664,
        NvAPI_EnumCustomDisplay = 0x42892957,
        NvAPI_EnumUnderscanConfig = 0x4144111A,
        NvAPI_Event_RegisterCallback = 0x0E6DBEA69,
        NvAPI_Event_UnregisterCallback = 0x0DE1F9B45,
        NvAPI_GetDisplayDriverBuildTitle = 0x7562E947,
        NvAPI_GetDisplayDriverCompileType = 0x988AEA78,
        NvAPI_GetDisplayDriverMemoryInfo = 0x774AA982,
        NvAPI_GetDisplayDriverRegistryPath = 0x0E24CEEE,
        NvAPI_GetDisplayDriverSecurityLevel = 0x9D772BBA,
        NvAPI_GetDisplayFeatureConfig = 0x8E985CCD,
        NvAPI_GetDisplayFeatureConfigDefaults = 0x0F5F4D01,
        NvAPI_GetDisplayPosition = 0x6BB1EE5D,
        NvAPI_GetDisplaySettings = 0x0DC27D5D4,
        NvAPI_GetDriverMemoryInfo = 0x2DC95125,
        NvAPI_GetDriverModel = 0x25EEB2C4,
        NvAPI_GetDVCInfo = 0x4085DE45,
        NvAPI_GetDVCInfoEx = 0x0E45002D,
        NvAPI_GetGPUIDfromPhysicalGPU = 0x6533EA3E,
        NvAPI_GetHDCPLinkParameters = 0x0B3BB0772,
        NvAPI_GetHUEInfo = 0x95B64341,
        NvAPI_GetHybridMode = 0x0E23B68C1,
        NvAPI_GetImageSharpeningInfo = 0x9FB063DF,
        NvAPI_GetInfoFrame = 0x9734F1D,
        NvAPI_GetInfoFrameState = 0x41511594,
        NvAPI_GetInfoFrameStatePvt = 0x7FC17574,
        NvAPI_GetInvalidGpuTopologies = 0x15658BE6,
        NvAPI_GetLoadedMicrocodePrograms = 0x919B3136,
        NvAPI_GetPhysicalGPUFromDisplay = 0x1890E8DA,
        NvAPI_GetPhysicalGPUFromGPUID = 0x5380AD1A,
        NvAPI_GetPVExtName = 0x2F5B08E0,
        NvAPI_GetPVExtProfile = 0x1B1B9A16,
        NvAPI_GetScalingCaps = 0x8E875CF9,
        NvAPI_GetTiming = 0x0AFC4833E,
        NvAPI_GetTopologyDisplayGPU = 0x813D89A8,
        NvAPI_GetTVEncoderControls = 0x5757474A,
        NvAPI_GetTVOutputBorderColor = 0x6DFD1C8C,
        NvAPI_GetTVOutputInfo = 0x30C805D5,
        NvAPI_GetUnAttachedDisplayDriverRegistryPath = 0x633252D8,
        NvAPI_GetValidGpuTopologies = 0x5DFAB48A,
        NvAPI_GetVideoState = 0x1C5659CD,
        NvAPI_GPS_GetPerfSensors = 0x271C1109,
        NvAPI_GPS_GetPowerSteeringStatus = 0x540EE82E,
        NvAPI_GPS_GetThermalLimit = 0x583113ED,
        NvAPI_GPS_GetVPStateCap = 0x71913023,
        NvAPI_GPS_SetPowerSteeringStatus = 0x9723D3A2,
        NvAPI_GPS_SetThermalLimit = 0x0C07E210F,
        NvAPI_GPS_SetVPStateCap = 0x68888EB4,
        NvAPI_GPU_ClearPCIELinkAERInfo = 0x521566BB,
        NvAPI_GPU_ClearPCIELinkErrorInfo = 0x8456FF3D,
        NvAPI_GPU_ClientPowerPoliciesGetInfo = 0x34206D86,
        NvAPI_GPU_ClientPowerPoliciesGetStatus = 0x70916171,
        NvAPI_GPU_ClientPowerPoliciesSetStatus = 0x0AD95F5ED,
        NvAPI_GPU_ClientPowerTopologyGetInfo = 0x0A4DFD3F2,
        NvAPI_GPU_ClientPowerTopologyGetStatus = 0x0EDCF624E,
        NvAPI_GPU_CudaEnumComputeCapableGpus = 0x5786CC6E,
        NvAPI_GPU_EnableDynamicPstates = 0x0FA579A0F,
        NvAPI_GPU_EnableOverclockedPstates = 0x0B23B70EE,
        NvAPI_GPU_Get_DisplayPort_DongleInfo = 0x76A70E8D,
        NvAPI_GPU_GetAllClocks = 0x1BD69F49,
        NvAPI_GPU_GetAllGpusOnSameBoard = 0x4DB019E6,
        NvAPI_GPU_GetArchInfo = 0xD8265D24,
        NvAPI_GPU_GetBarInfo = 0xE4B701E3,
        NvAPI_GPU_GetClockBoostLock = 0xe440b867, // unknown name, NVAPI_ID_CURVE_GET
        NvAPI_GPU_GetClockBoostMask = 0x507b4b59,
        NvAPI_GPU_GetClockBoostRanges = 0x64b43a6a,
        NvAPI_GPU_GetClockBoostTable = 0x23f1b133,
        NvAPI_GPU_GetColorSpaceConversion = 0x8159E87A,
        NvAPI_GPU_GetConnectorInfo = 0x4ECA2C10,
        NvAPI_GPU_GetCoolerPolicyTable = 0x518A32C,
        NvAPI_GPU_GetCoolerSettings = 0x0DA141340,
        NvAPI_GPU_GetCoreVoltageBoostPercent = 0x9df23ca1,
        NvAPI_GPU_GetCurrentFanSpeedLevel = 0x0BD71F0C9,
        NvAPI_GPU_GetCurrentThermalLevel = 0x0D2488B79,
        NvAPI_GPU_GetCurrentVoltage = 0x465f9bcf,
        NvAPI_GPU_GetDeepIdleState = 0x1AAD16B4,
        NvAPI_GPU_GetDeviceDisplayMode = 0x0D2277E3A,
        NvAPI_GPU_GetDisplayUnderflowStatus = 0xED9E8057,
        NvAPI_GPU_GetDitherControl = 0x932AC8FB,
        NvAPI_GPU_GetExtendedMinorRevision = 0x25F17421,
        NvAPI_GPU_GetFBWidthAndLocation = 0x11104158,
        NvAPI_GPU_GetFlatPanelInfo = 0x36CFF969,
        NvAPI_GPU_GetFoundry = 0x5D857A00,
        NvAPI_GPU_GetFrameBufferCalibrationLockFailures = 0x524B9773,
        NvAPI_GPU_GetHardwareQualType = 0xF91E777B,
        NvAPI_GPU_GetHybridControllerInfo = 0xD26B8A58,
        NvAPI_GPU_GetLogicalFBWidthAndLocation = 0x8efc0978,
        NvAPI_GPU_GetManufacturingInfo = 0xA4218928,
        NvAPI_GPU_GetMemPartitionMask = 0x329D77CD,
        NvAPI_GPU_GetMXMBlock = 0xB7AB19B9,
        NvAPI_GPU_GetPartitionCount = 0x86F05D7A,
        NvAPI_GPU_GetPCIEInfo = 0xE3795199,
        NvAPI_GPU_GetPerfClocks = 0x1EA54A3B,
        NvAPI_GPU_GetPerfHybridMode = 0x5D7CCAEB,
        NvAPI_GPU_GetPerGpuTopologyStatus = 0x0A81F8992,
        NvAPI_GPU_GetPixelClockRange = 0x66AF10B7,
        NvAPI_GPU_GetPowerMizerInfo = 0x76BFA16B,
        NvAPI_GPU_GetPSFloorSweepStatus = 0xDEE047AB,
        NvAPI_GPU_GetPstateClientLimits = 0x88C82104,
        NvAPI_GPU_GetPstatesInfo = 0x0BA94C56E,
        NvAPI_GPU_GetRamBankCount = 0x17073A3C,
        NvAPI_GPU_GetRamBusWidth = 0x7975C581,
        NvAPI_GPU_GetRamConfigStrap = 0x51CCDB2A,
        NvAPI_GPU_GetRamMaker = 0x42aea16a,
        NvAPI_GPU_GetRamType = 0x57F7CAAC,
        NvAPI_GPU_GetRawFuseData = 0xE0B1DCE9,
        NvAPI_GPU_GetROPCount = 0xfdc129fa,
        NvAPI_GPU_GetSampleType = 0x32E1D697,
        NvAPI_GPU_GetSerialNumber = 0x14B83A5F,
        NvAPI_GPU_GetShaderPipeCount = 0x63E2F56F,
        NvAPI_GPU_GetShortName = 0xD988F0F3,
        NvAPI_GPU_GetSMMask = 0x0EB7AF173,
        NvAPI_GPU_GetTargetID = 0x35B5FD2F,
        NvAPI_GPU_GetThermalPoliciesInfo = 0x00D258BB5, // NvAPI_GPU_ClientThermalPoliciesGetInfo
        NvAPI_GPU_GetThermalPoliciesStatus = 0x0E9C425A1,
        NvAPI_GPU_GetThermalTable = 0xC729203C,
        NvAPI_GPU_GetTotalSMCount = 0x0AE5FBCFE,
        NvAPI_GPU_GetTotalSPCount = 0x0B6D62591,
        NvAPI_GPU_GetTotalTPCCount = 0x4E2F76A8,
        NvAPI_GPU_GetTPCMask = 0x4A35DF54,
        NvAPI_GPU_GetUsages = 0x189a1fdf,
        NvAPI_GPU_GetVbiosImage = 0xFC13EE11,
        NvAPI_GPU_GetVbiosMxmVersion = 0xE1D5DABA,
        NvAPI_GPU_GetVFPCurve = 0x21537ad4,
        NvAPI_GPU_GetVoltageDomainsStatus = 0x0C16C7E2C,
        NvAPI_GPU_GetVoltages = 0x7D656244,
        NvAPI_GPU_GetVoltageStep = 0x28766157, // unsure of the name
        NvAPI_GPU_GetVPECount = 0xD8CBF37B,
        NvAPI_GPU_GetVSFloorSweepStatus = 0xD4F3944C,
        NvAPI_GPU_GPIOQueryLegalPins = 0x0FAB69565,
        NvAPI_GPU_GPIOReadFromPin = 0x0F5E10439,
        NvAPI_GPU_GPIOWriteToPin = 0x0F3B11E68,
        NvAPI_GPU_PerfPoliciesGetInfo = 0x409d9841,
        NvAPI_GPU_PerfPoliciesGetStatus = 0x3d358a0c,
        NvAPI_GPU_PhysxQueryRecommendedState = 0x7A4174F4,
        NvAPI_GPU_PhysxSetState = 0x4071B85E,
        NvAPI_GPU_QueryActiveApps = 0x65B1C5F5,
        NvAPI_GPU_RestoreCoolerPolicyTable = 0x0D8C4FE63,
        NvAPI_GPU_RestoreCoolerSettings = 0x8F6ED0FB,
        NvAPI_GPU_SetClockBoostLock = 0x39442cfb, // unknown name, NVAPI_ID_CURVE_SET
        NvAPI_GPU_SetClockBoostTable = 0x0733e009,
        NvAPI_GPU_SetClocks = 0x6F151055,
        NvAPI_GPU_SetColorSpaceConversion = 0x0FCABD23A,
        NvAPI_GPU_SetCoolerLevels = 0x891FA0AE,
        NvAPI_GPU_SetCoolerPolicyTable = 0x987947CD,
        NvAPI_GPU_SetCoreVoltageBoostPercent = 0xb9306d9b,
        NvAPI_GPU_SetCurrentPCIESpeed = 0x3BD32008,
        NvAPI_GPU_SetCurrentPCIEWidth = 0x3F28E1B9,
        NvAPI_GPU_SetDeepIdleState = 0x568A2292,
        NvAPI_GPU_SetDisplayUnderflowMode = 0x387B2E41,
        NvAPI_GPU_SetDitherControl = 0x0DF0DFCDD,
        NvAPI_GPU_SetPerfClocks = 0x7BCF4AC,
        NvAPI_GPU_SetPerfHybridMode = 0x7BC207F8,
        NvAPI_GPU_SetPixelClockRange = 0x5AC7F8E5,
        NvAPI_GPU_SetPowerMizerInfo = 0x50016C78,
        NvAPI_GPU_SetPstateClientLimits = 0x0FDFC7D49,
        NvAPI_GPU_SetPstates20 = 0x0F4DAE6B,
        NvAPI_GPU_SetPstatesInfo = 0x0CDF27911,
        NvAPI_GPU_SetThermalPoliciesStatus = 0x034C0B13D,
        NvAPI_Hybrid_IsAppMigrationStateChangeable = 0x584CB0B6,
        NvAPI_Hybrid_QueryBlockedMigratableApps = 0x0F4C2F8CC,
        NvAPI_Hybrid_QueryUnblockedNonMigratableApps = 0x5F35BCB5,
        NvAPI_Hybrid_SetAppMigrationState = 0x0FA0B9A59,
        NvAPI_I2CReadEx = 0x4D7B0709,
        NvAPI_I2CWriteEx = 0x283AC65A,
        NvAPI_LoadMicrocode = 0x3119F36E,
        NvAPI_Mosaic_ChooseGpuTopologies = 0x0B033B140,
        NvAPI_Mosaic_EnumGridTopologies = 0x0A3C55220,
        NvAPI_Mosaic_GetDisplayCapabilities = 0x0D58026B9,
        NvAPI_Mosaic_GetMosaicCapabilities = 0x0DA97071E,
        NvAPI_Mosaic_GetMosaicViewports = 0x7EBA036,
        NvAPI_Mosaic_SetGridTopology = 0x3F113C77,
        NvAPI_Mosaic_ValidateDisplayGridsWithSLI = 0x1ECFD263,
        NvAPI_QueryNonMigratableApps = 0x0BB9EF1C3,
        NvAPI_QueryUnderscanCap = 0x61D7B624,
        NvAPI_RestartDisplayDriver = 0xB4B26B65,
        NvAPI_RevertCustomDisplayTrial = 0x854BA405,
        NvAPI_SaveCustomDisplay = 0x0A9062C78,
        NvAPI_SetDisplayFeatureConfig = 0x0F36A668D,
        NvAPI_SetDisplayPosition = 0x57D9060F,
        NvAPI_SetDisplaySettings = 0x0E04F3D86,
        NvAPI_SetDVCLevel = 0x172409B4,
        NvAPI_SetDVCLevelEx = 0x4A82C2B1,
        NvAPI_SetFrameRateNotify = 0x18919887,
        NvAPI_SetGpuTopologies = 0x25201F3D,
        NvAPI_SetHUEAngle = 0x0F5A0F22C,
        NvAPI_SetHybridMode = 0x0FB22D656,
        NvAPI_SetImageSharpeningLevel = 0x3FC9A59C,
        NvAPI_SetInfoFrame = 0x69C6F365,
        NvAPI_SetInfoFrameState = 0x67EFD887,
        NvAPI_SetPVExtName = 0x4FEEB498,
        NvAPI_SetPVExtProfile = 0x8354A8F4,
        NvAPI_SetTopologyDisplayGPU = 0xF409D5E5,
        NvAPI_SetTopologyFocusDisplayAndView = 0x0A8064F9,
        NvAPI_SetTVEncoderControls = 0x0CA36A3AB,
        NvAPI_SetTVOutputBorderColor = 0x0AED02700,
        NvAPI_SetUnderscanConfig = 0x3EFADA1D,
        NvAPI_SetVideoState = 0x54FE75A,
        NvAPI_Stereo_AppHandShake = 0x8C610BDA,
        NvAPI_Stereo_ForceToScreenDepth = 0x2D495758,
        NvAPI_Stereo_GetCursorSeparation = 0x72162B35,
        NvAPI_Stereo_GetPixelShaderConstantB = 0x0C79333AE,
        NvAPI_Stereo_GetPixelShaderConstantF = 0x0D4974572,
        NvAPI_Stereo_GetPixelShaderConstantI = 0x0ECD8F8CF,
        NvAPI_Stereo_GetStereoCaps = 0x0DFC063B7,
        NvAPI_Stereo_GetVertexShaderConstantB = 0x712BAA5B,
        NvAPI_Stereo_GetVertexShaderConstantF = 0x622FDC87,
        NvAPI_Stereo_GetVertexShaderConstantI = 0x5A60613A,
        NvAPI_Stereo_HandShake_Message_Control = 0x315E0EF0,
        NvAPI_Stereo_HandShake_Trigger_Activation = 0x0B30CD1A7,
        NvAPI_Stereo_Is3DCursorSupported = 0x0D7C9EC09,
        NvAPI_Stereo_SetCursorSeparation = 0x0FBC08FC1,
        NvAPI_Stereo_SetPixelShaderConstantB = 0x0BA6109EE,
        NvAPI_Stereo_SetPixelShaderConstantF = 0x0A9657F32,
        NvAPI_Stereo_SetPixelShaderConstantI = 0x912AC28F,
        NvAPI_Stereo_SetVertexShaderConstantB = 0x5268716F,
        NvAPI_Stereo_SetVertexShaderConstantF = 0x416C07B3,
        NvAPI_Stereo_SetVertexShaderConstantI = 0x7923BA0E,
        NvAPI_SYS_GetChipSetTopologyStatus = 0x8A50F126,
        NvAPI_SYS_GetSliApprovalCookie = 0xB539A26E,
        NvAPI_SYS_SetPostOutput = 0xD3A092B1,
        NvAPI_SYS_VenturaGetCoolingBudget = 0x0C9D86E33,
        NvAPI_SYS_VenturaGetPowerReading = 0x63685979,
        NvAPI_SYS_VenturaGetState = 0x0CB7C208D,
        NvAPI_SYS_VenturaSetCoolingBudget = 0x85FF5A15,
        NvAPI_SYS_VenturaSetState = 0x0CE2E9D9,
        NvAPI_TryCustomDisplay = 0x0BF6C1762,
        NvAPI_VideoGetStereoInfo = 0x8E1F8CFE,
        NvAPI_VideoSetStereoInfo = 0x97063269,
        NvAPI_GPU_ClientFanCoolersGetInfo = 0xfb85b01e,
        NvAPI_GPU_ClientFanCoolersGetStatus = 0x35aed5e8,
        NvAPI_GPU_ClientFanCoolersGetControl = 0x814b209f,
        NvAPI_GPU_ClientFanCoolersSetControl = 0xa58971a5,
        Unknown_1629A173 = 0x1629a173, // `Unknown(*mut { version = 0x00030038, count, .. })`
        Unknown_36E39E6B = 0x36e39e6b, // `Unknown(*mut { version = 0x0002000c, count, ... })` might be handles?
        Unknown_B7BCF50D = 0xb7bcf50d, // `Unknown(hGpu, *mut { version = 0x00010008, value })` seen `value = 0x703`
        Unknown_F1D2777B = 0xf1d2777b, // `Unknown(hDisplayHandle, *mut hGpu)` maybe?


        NvAPI_Unload = 0xD22BDD7E,
        NvAPI_Initialize = 0x150E828
    }

    /// <summary>
    /// All functions return an NvAPI_Status value. For example,
    /// 
    /// Any function receiving an invalid argument will return NVAPI_INVALID_ARGUMENT.
    /// If communication with an NVIDIA display driver cannot be established, functions return NVAPI_NVIDIA_DEVICE_NOT_FOUND.
    /// If one or more handles passed have been invalidated due to a modeset or SLI reconfiguration event, then functions return NVAPI_HANDLE_INVALIDATED.
    /// </summary>
    public enum NvAPI_Status
    {
        /// <summary>
        /// Success. Request is completed.
        /// </summary>
        NVAPI_OK = 0,
        /// <summary>
        /// Generic error.
        /// </summary>
        NVAPI_ERROR = -1,
        /// <summary>
        /// NVAPI support library cannot be loaded.
        /// </summary>
        NVAPI_LIBRARY_NOT_FOUND = -2,
        /// <summary>
        /// not implemented in current driver installation
        /// </summary>
        NVAPI_NO_IMPLEMENTATION = -3,
        /// <summary>
        /// NvAPI_Initialize has not been called (successfully)
        /// </summary>
        NVAPI_API_NOT_INITIALIZED = -4,
        /// <summary>
        /// The argument/parameter value is not valid or NULL.
        /// </summary>
        NVAPI_INVALID_ARGUMENT = -5,
        /// <summary>
        /// No NVIDIA display driver, or NVIDIA GPU driving a display, was found.
        /// </summary>
        NVAPI_NVIDIA_DEVICE_NOT_FOUND = -6,
        /// <summary>
        /// No more items to enumerate.
        /// </summary>
        NVAPI_END_ENUMERATION = -7,
        /// <summary>
        /// Invalid handle.
        /// </summary>
        NVAPI_INVALID_HANDLE = -8,
        /// <summary>
        /// An argument's structure version is not supported.
        /// </summary>
        NVAPI_INCOMPATIBLE_STRUCT_VERSION = -9,
        /// <summary>
        /// The handle is no longer valid (likely due to GPU or display re-configuration)
        /// </summary>
        NVAPI_HANDLE_INVALIDATED = -10,
        /// <summary>
        /// No NVIDIA OpenGL context is current (but needs to be)
        /// </summary>
        NVAPI_OPENGL_CONTEXT_NOT_CURRENT = -11,
        /// <summary>
        /// An invalid pointer, usually NULL, was passed as a parameter.
        /// </summary>
        NVAPI_INVALID_POINTER = -14,
        /// <summary>
        /// OpenGL Expert is not supported by the current drivers.
        /// </summary>
        NVAPI_NO_GL_EXPERT = -12,
        /// <summary>
        /// OpenGL Expert is supported, but driver instrumentation is currently disabled.
        /// </summary>
        NVAPI_INSTRUMENTATION_DISABLED = -13,
        /// <summary>
        /// OpenGL does not support Nsight.
        /// </summary>
        NVAPI_NO_GL_NSIGHT = -15,
        /// <summary>
        /// Expected a logical GPU handle for one or more parameters.
        /// </summary>
        NVAPI_EXPECTED_LOGICAL_GPU_HANDLE = -100,
        /// <summary>
        /// Expected a physical GPU handle for one or more parameters.
        /// </summary>
        NVAPI_EXPECTED_PHYSICAL_GPU_HANDLE = -101,
        /// <summary>
        /// Expected an NV display handle for one or more parameters.
        /// </summary>
        NVAPI_EXPECTED_DISPLAY_HANDLE = -102,
        /// <summary>
        /// The combination of parameters is not valid.
        /// </summary>
        NVAPI_INVALID_COMBINATION = -103,
        /// <summary>
        /// Requested feature is not supported in the selected GPU.
        /// </summary>
        NVAPI_NOT_SUPPORTED = -104,
        /// <summary>
        /// No port ID was found for the I2C transaction.
        /// </summary>
        NVAPI_PORTID_NOT_FOUND = -105,
        /// <summary>
        /// Expected an unattached display handle as one of the input parameters.
        /// </summary>
        NVAPI_EXPECTED_UNATTACHED_DISPLAY_HANDLE = -106,
        /// <summary>
        /// Invalid perf level.
        /// </summary>
        NVAPI_INVALID_PERF_LEVEL = -107,
        /// <summary>
        /// Device is busy; request not fulfilled.
        /// </summary>
        NVAPI_DEVICE_BUSY = -108,
        /// <summary>
        /// NV persist file is not found.
        /// </summary>
        NVAPI_NV_PERSIST_FILE_NOT_FOUND = -109,
        /// <summary>
        /// NV persist data is not found.
        /// </summary>
        NVAPI_PERSIST_DATA_NOT_FOUND = -110,
        /// <summary>
        /// Expected a TV output display.
        /// </summary>
        NVAPI_EXPECTED_TV_DISPLAY = -111,
        /// <summary>
        /// Expected a TV output on the D Connector - HDTV_EIAJ4120.
        /// </summary>
        NVAPI_EXPECTED_TV_DISPLAY_ON_DCONNECTOR = -112,
        /// <summary>
        /// SLI is not active on this device.
        /// </summary>
        NVAPI_NO_ACTIVE_SLI_TOPOLOGY = -113,
        /// <summary>
        /// Setup of SLI rendering mode is not possible right now.
        /// </summary>
        NVAPI_SLI_RENDERING_MODE_NOTALLOWED = -114,
        /// <summary>
        /// Expected a digital flat panel.
        /// </summary>
        NVAPI_EXPECTED_DIGITAL_FLAT_PANEL = -115,
        /// <summary>
        /// Argument exceeds the expected size.
        /// </summary>
        NVAPI_ARGUMENT_EXCEED_MAX_SIZE = -116,
        /// <summary>
        /// Inhibit is ON due to one of the flags in NV_GPU_DISPLAY_CHANGE_INHIBIT or SLI active.
        /// </summary>
        NVAPI_DEVICE_SWITCHING_NOT_ALLOWED = -117,
        /// <summary>
        /// Testing of clocks is not supported.
        /// </summary>
        NVAPI_TESTING_CLOCKS_NOT_SUPPORTED = -118,
        /// <summary>
        /// The specified underscan config is from an unknown source (e.g. INF)
        /// </summary>
        NVAPI_UNKNOWN_UNDERSCAN_CONFIG = -119,
        /// <summary>
        /// Timeout while reconfiguring GPUs.
        /// </summary>
        NVAPI_TIMEOUT_RECONFIGURING_GPU_TOPO = -120,
        /// <summary>
        /// Requested data was not found.
        /// </summary>
        NVAPI_DATA_NOT_FOUND = -121,
        /// <summary>
        /// Expected an analog display.
        /// </summary>
        NVAPI_EXPECTED_ANALOG_DISPLAY = -122,
        /// <summary>
        /// No SLI video bridge is present.
        /// </summary>
        NVAPI_NO_VIDLINK = -123,
        /// <summary>
        /// NVAPI requires a reboot for the settings to take effect.
        /// </summary>
        NVAPI_REQUIRES_REBOOT = -124,
        /// <summary>
        /// The function is not supported with the current Hybrid mode.
        /// </summary>
        NVAPI_INVALID_HYBRID_MODE = -125,
        /// <summary>
        /// The target types are not all the same.
        /// </summary>
        NVAPI_MIXED_TARGET_TYPES = -126,
        /// <summary>
        /// The function is not supported from 32-bit on a 64-bit system.
        /// </summary>
        NVAPI_SYSWOW64_NOT_SUPPORTED = -127,
        /// <summary>
        /// There is no implicit GPU topology active. Use NVAPI_SetHybridMode to change topology.
        /// </summary>
        NVAPI_IMPLICIT_SET_GPU_TOPOLOGY_CHANGE_NOT_ALLOWED = -128,
        /// <summary>
        /// Prompt the user to close all non-migratable applications.
        /// </summary>
        NVAPI_REQUEST_USER_TO_CLOSE_NON_MIGRATABLE_APPS = -129,
        /// <summary>
        /// Could not allocate sufficient memory to complete the call.
        /// </summary>
        NVAPI_OUT_OF_MEMORY = -130,
        /// <summary>
        /// The previous operation that is transferring information to or from this surface is incomplete.
        /// </summary>
        NVAPI_WAS_STILL_DRAWING = -131,
        /// <summary>
        /// The file was not found.
        /// </summary>
        NVAPI_FILE_NOT_FOUND = -132,
        /// <summary>
        /// There are too many unique instances of a particular type of state object.
        /// </summary>
        NVAPI_TOO_MANY_UNIQUE_STATE_OBJECTS = -133,
        /// <summary>
        /// The method call is invalid. For example, a method's parameter may not be a valid pointer.
        /// </summary>
        NVAPI_INVALID_CALL = -134,
        /// <summary>
        /// d3d10_1.dll cannot be loaded.
        /// </summary>
        NVAPI_D3D10_1_LIBRARY_NOT_FOUND = -135,
        /// <summary>
        /// Couldn't find the function in the loaded DLL.
        /// </summary>
        NVAPI_FUNCTION_NOT_FOUND = -136,
        /// <summary>
        /// The application can be elevated to a higher permission level by selecting "Run as Administrator".
        ///
        /// The application will require Administrator privileges to access this API.
        /// </summary>
        NVAPI_INVALID_USER_PRIVILEGE = -137,
        /// <summary>
        /// The handle corresponds to GDIPrimary.
        /// </summary>
        NVAPI_EXPECTED_NON_PRIMARY_DISPLAY_HANDLE = -138,
        /// <summary>
        /// Setting Physx GPU requires that the GPU is compute-capable.
        /// </summary>
        NVAPI_EXPECTED_COMPUTE_GPU_HANDLE = -139,
        /// <summary>
        /// The Stereo part of NVAPI failed to initialize completely. Check if the stereo driver is installed.
        /// </summary>
        NVAPI_STEREO_NOT_INITIALIZED = -140,
        /// <summary>
        /// Access to stereo-related registry keys or values has failed.
        /// </summary>
        NVAPI_STEREO_REGISTRY_ACCESS_FAILED = -141,
        /// <summary>
        /// The given registry profile type is not supported.
        /// </summary>
        NVAPI_STEREO_REGISTRY_PROFILE_TYPE_NOT_SUPPORTED = -142,
        /// <summary>
        /// The given registry value is not supported.
        /// </summary>
        NVAPI_STEREO_REGISTRY_VALUE_NOT_SUPPORTED = -143,
        /// <summary>
        /// Stereo is not enabled and the function needed it to execute completely.
        /// </summary>
        NVAPI_STEREO_NOT_ENABLED = -144,
        /// <summary>
        /// Stereo is not turned on and the function needed it to execute completely.
        /// </summary>
        NVAPI_STEREO_NOT_TURNED_ON = -145,
        /// <summary>
        /// Invalid device interface.
        /// </summary>
        NVAPI_STEREO_INVALID_DEVICE_INTERFACE = -146,
        /// <summary>
        /// Separation percentage or JPEG image capture quality is out of [0-100] range.
        /// </summary>
        NVAPI_STEREO_PARAMETER_OUT_OF_RANGE = -147,
        /// <summary>
        /// The given frustum adjust mode is not supported.
        /// </summary>
        NVAPI_STEREO_FRUSTUM_ADJUST_MODE_NOT_SUPPORTED = -148,
        /// <summary>
        /// The mosaic topology is not possible given the current state of the hardware.
        /// </summary>
        NVAPI_TOPO_NOT_POSSIBLE = -149,
        /// <summary>
        /// An attempt to do a display resolution mode change has failed.
        /// </summary>
        NVAPI_MODE_CHANGE_FAILED = -150,
        /// <summary>
        /// d3d11.dll/d3d11_beta.dll cannot be loaded.
        /// </summary>
        NVAPI_D3D11_LIBRARY_NOT_FOUND = -151,
        /// <summary>
        /// Address is outside of valid range.
        /// </summary>
        NVAPI_INVALID_ADDRESS = -152,
        /// <summary>
        /// The pre-allocated string is too small to hold the result.
        /// </summary>
        NVAPI_STRING_TOO_SMALL = -153,
        /// <summary>
        /// The input does not match any of the available devices.
        /// </summary>
        NVAPI_MATCHING_DEVICE_NOT_FOUND = -154,
        /// <summary>
        /// Driver is running.
        /// </summary>
        NVAPI_DRIVER_RUNNING = -155,
        /// <summary>
        /// Driver is not running.
        /// </summary>
        NVAPI_DRIVER_NOTRUNNING = -156,
        /// <summary>
        /// A driver reload is required to apply these settings.
        /// </summary>
        NVAPI_ERROR_DRIVER_RELOAD_REQUIRED = -157,
        /// <summary>
        /// Intended setting is not allowed.
        /// </summary>
        NVAPI_SET_NOT_ALLOWED = -158,
        /// <summary>
        /// Information can't be returned due to "advanced display topology".
        /// </summary>
        NVAPI_ADVANCED_DISPLAY_TOPOLOGY_REQUIRED = -159,
        /// <summary>
        /// Setting is not found.
        /// </summary>
        NVAPI_SETTING_NOT_FOUND = -160,
        /// <summary>
        /// Setting size is too large.
        /// </summary>
        NVAPI_SETTING_SIZE_TOO_LARGE = -161,
        /// <summary>
        /// There are too many settings for a profile.
        /// </summary>
        NVAPI_TOO_MANY_SETTINGS_IN_PROFILE = -162,
        /// <summary>
        /// Profile is not found.
        /// </summary>
        NVAPI_PROFILE_NOT_FOUND = -163,
        /// <summary>
        /// Profile name is duplicated.
        /// </summary>
        NVAPI_PROFILE_NAME_IN_USE = -164,
        /// <summary>
        /// Profile name is empty.
        /// </summary>
        NVAPI_PROFILE_NAME_EMPTY = -165,
        /// <summary>
        /// Application not found in the Profile.
        /// </summary>
        NVAPI_EXECUTABLE_NOT_FOUND = -166,
        /// <summary>
        /// Application already exists in the other profile.
        /// </summary>
        NVAPI_EXECUTABLE_ALREADY_IN_USE = -167,
        /// <summary>
        /// Data Type mismatch.
        /// </summary>
        NVAPI_DATATYPE_MISMATCH = -168,
        /// <summary>
        /// The profile passed as parameter has been removed and is no longer valid.
        /// </summary>
        NVAPI_PROFILE_REMOVED = -169,
        /// <summary>
        /// An unregistered resource was passed as a parameter.
        /// </summary>
        NVAPI_UNREGISTERED_RESOURCE = -170,
        /// <summary>
        /// The DisplayId corresponds to a display which is not within the normal outputId range.
        /// </summary>
        NVAPI_ID_OUT_OF_RANGE = -171,
        /// <summary>
        /// Display topology is not valid so the driver cannot do a mode set on this configuration.
        /// </summary>
        NVAPI_DISPLAYCONFIG_VALIDATION_FAILED = -172,
        /// <summary>
        /// Display Port Multi-Stream topology has been changed.
        /// </summary>
        NVAPI_DPMST_CHANGED = -173,
        /// <summary>
        /// Input buffer is insufficient to hold the contents.
        /// </summary>
        NVAPI_INSUFFICIENT_BUFFER = -174,
        /// <summary>
        /// No access to the caller.
        /// </summary>
        NVAPI_ACCESS_DENIED = -175,
        /// <summary>
        /// The requested action cannot be performed without Mosaic being enabled.
        /// </summary>
        NVAPI_MOSAIC_NOT_ACTIVE = -176,
        /// <summary>
        /// The surface is relocated away from video memory.
        /// </summary>
        NVAPI_SHARE_RESOURCE_RELOCATED = -177,
        /// <summary>
        /// The user should disable DWM before calling NvAPI.
        /// </summary>
        NVAPI_REQUEST_USER_TO_DISABLE_DWM = -178,
        /// <summary>
        /// D3D device status is D3DERR_DEVICELOST or D3DERR_DEVICENOTRESET - the user has to reset the device.
        /// </summary>
        NVAPI_D3D_DEVICE_LOST = -179,
        /// <summary>
        /// The requested action cannot be performed in the current state.
        /// </summary>
        NVAPI_INVALID_CONFIGURATION = -180,
        /// <summary>
        /// Call failed as stereo handshake not completed.
        /// </summary>
        NVAPI_STEREO_HANDSHAKE_NOT_DONE = -181,
        /// <summary>
        /// The path provided was too short to determine the correct NVDRS_APPLICATION.
        /// </summary>
        NVAPI_EXECUTABLE_PATH_IS_AMBIGUOUS = -182,
        /// <summary>
        /// Default stereo profile is not currently defined.
        /// </summary>
        NVAPI_DEFAULT_STEREO_PROFILE_IS_NOT_DEFINED = -183,
        /// <summary>
        /// Default stereo profile does not exist.
        /// </summary>
        NVAPI_DEFAULT_STEREO_PROFILE_DOES_NOT_EXIST = -184,
        /// <summary>
        /// A cluster is already defined with the given configuration.
        /// </summary>
        NVAPI_CLUSTER_ALREADY_EXISTS = -185,
        /// <summary>
        /// The input display id is not that of a multi stream enabled connector or a display device in a multi stream topology.
        /// </summary>
        NVAPI_DPMST_DISPLAY_ID_EXPECTED = -186,
        /// <summary>
        /// The input display id is not valid or the monitor associated to it does not support the current operation.
        /// </summary>
        NVAPI_INVALID_DISPLAY_ID = -187,
        /// <summary>
        /// While playing secure audio stream, stream goes out of sync.
        /// </summary>
        NVAPI_STREAM_IS_OUT_OF_SYNC = -188,
        /// <summary>
        /// Older audio driver version than required.
        /// </summary>
        NVAPI_INCOMPATIBLE_AUDIO_DRIVER = -189,
        /// <summary>
        /// Value already set, setting again not allowed.
        /// </summary>
        NVAPI_VALUE_ALREADY_SET = -190,
        /// <summary>
        /// Requested operation timed out.
        /// </summary>
        NVAPI_TIMEOUT = -191,
        /// <summary>
        /// The requested workstation feature set has incomplete driver internal allocation resources.
        /// </summary>
        NVAPI_GPU_WORKSTATION_FEATURE_INCOMPLETE = -192,
        /// <summary>
        /// Call failed because InitActivation was not called.
        /// </summary>
        NVAPI_STEREO_INIT_ACTIVATION_NOT_DONE = -193,
        /// <summary>
        /// The requested action cannot be performed without Sync being enabled.
        /// </summary>
        NVAPI_SYNC_NOT_ACTIVE = -194,
        /// <summary>
        /// The requested action cannot be performed without Sync Master being enabled.
        /// </summary>
        NVAPI_SYNC_MASTER_NOT_FOUND = -195,
        /// <summary>
        /// Invalid displays passed in the NV_GSYNC_DISPLAY pointer.
        /// </summary>
        NVAPI_INVALID_SYNC_TOPOLOGY = -196,
        /// <summary>
        /// The specified signing algorithm is not supported. Either an incorrect value was entered or the current installed driver/hardware does not support the input value.
        /// </summary>
        NVAPI_ECID_SIGN_ALGO_UNSUPPORTED = -197,
        /// <summary>
        /// The encrypted public key verification has failed.
        /// </summary> 
        NVAPI_ECID_KEY_VERIFICATION_FAILED = -198,
        /// <summary>
        /// The device's firmware is out of date.
        /// </summary>
        NVAPI_FIRMWARE_OUT_OF_DATE = -199,
        /// <summary>
        /// The device's firmware is not supported.
        /// </summary>
        NVAPI_FIRMWARE_REVISION_NOT_SUPPORTED = -200,
        /// <summary>
        /// The caller is not authorized to modify the License.
        /// </summary>
        NVAPI_LICENSE_CALLER_AUTHENTICATION_FAILED = -201,
        /// <summary>
        /// The user tried to use a deferred context without registering the device first.
        /// </summary>
        NVAPI_D3D_DEVICE_NOT_REGISTERED = -202,
        /// <summary>
        /// Head or SourceId was not reserved for the VR Display before doing the Modeset or the dedicated display.
        /// </summary>
        NVAPI_RESOURCE_NOT_ACQUIRED = -203,
        /// <summary>
        /// Provided timing is not supported.
        /// </summary>
        NVAPI_TIMING_NOT_SUPPORTED = -204,
        /// <summary>
        /// HDCP Encryption Failed for the device. Would be applicable when the device is HDCP Capable.
        /// </summary>
        NVAPI_HDCP_ENCRYPTION_FAILED = -205,
        /// <summary>
        /// Provided mode is over sink device pclk limitation.
        /// </summary>
        NVAPI_PCLK_LIMITATION_FAILED = -206,
        /// <summary>
        /// No connector on GPU found.
        /// </summary>
        NVAPI_NO_CONNECTOR_FOUND = -207,
        /// <summary>
        /// When a non-HDCP capable HMD is connected, we would inform user by this code.
        /// </summary>
        NVAPI_HDCP_DISABLED = -208,
        /// <summary>
        /// Atleast an API is still being called.
        /// </summary>
        NVAPI_API_IN_USE = -209,
        /// <summary>
        /// No display found on Nvidia GPU(s).
        /// </summary>
        NVAPI_NVIDIA_DISPLAY_NOT_FOUND = -210,
        /// <summary>
        /// Priv security violation, improper access to a secured register.
        /// </summary>
        NVAPI_PRIV_SEC_VIOLATION = -211,
        /// <summary>
        /// NVAPI cannot be called by this vendor.
        /// </summary>
        NVAPI_INCORRECT_VENDOR = -212,
        /// <summary>
        /// DirectMode Display is already in use.
        /// </summary>
        NVAPI_DISPLAY_IN_USE = -213,
        /// <summary>
        /// The Config is having Non-NVidia GPU with Non-HDCP HMD connected.
        /// </summary>
        NVAPI_UNSUPPORTED_CONFIG_NON_HDCP_HMD = -214,
        /// <summary>
        /// GPU's Max Display Limit has Reached.
        /// </summary>
        NVAPI_MAX_DISPLAY_LIMIT_REACHED = -215,
        /// <summary>
        /// DirectMode not Enabled on the Display.
        /// </summary>
        NVAPI_INVALID_DIRECT_MODE_DISPLAY = -216,
        /// <summary>
        /// GPU is in debug mode, OC is NOT allowed.
        /// </summary>
        NVAPI_GPU_IN_DEBUG_MODE = -217,
        /// <summary>
        /// No NvAPI context was found for this D3D object.
        /// </summary>
        NVAPI_D3D_CONTEXT_NOT_FOUND = -218,
        /// <summary>
        /// there is version mismatch between stereo driver and dx driver
        /// </summary?
        NVAPI_STEREO_VERSION_MISMATCH = -219,
        /// <summary>
        /// GPU is not powered and so the request cannot be completed.
        /// </summary>
        NVAPI_GPU_NOT_POWERED = -220,
        /// <summary>
        /// The display driver update in progress.
        /// </summary>
        NVAPI_ERROR_DRIVER_RELOAD_IN_PROGRESS = -221,
        /// <summary>
        /// Wait for HW resources allocation.
        /// </summary>
        NVAPI_WAIT_FOR_HW_RESOURCE = -222,
        /// <summary>
        /// operation requires further HDCP action
        /// </summary>
        NVAPI_REQUIRE_FURTHER_HDCP_ACTION = -223,
        /// <summary>
        /// Dynamic Mux transition failure.
        /// </summary>
        NVAPI_DISPLAY_MUX_TRANSITION_FAILED = -224,
        /// <summary>
        /// Invalid DSC version.
        /// </summary>
        NVAPI_INVALID_DSC_VERSION = -225,
        /// <summary>
        /// Invalid DSC slice count.
        /// </summary>
        NVAPI_INVALID_DSC_SLICECOUNT = -226,
        /// <summary>
        /// Invalid DSC output BPP.
        /// </summary>
        NVAPI_INVALID_DSC_OUTPUT_BPP = -227,
        /// <summary>
        /// There was an error while loading nvapi.dll from the driver store.
        /// </summary>
        NVAPI_FAILED_TO_LOAD_FROM_DRIVER_STORE = -228,
        /// <summary>
        /// OpenGL does not export Vulkan fake extensions.
        /// </summary>
        NVAPI_NO_VULKAN = -229,
        /// <summary>
        /// A request for NvTOPPs telemetry CData has already been made and is pending a response.
        /// </summary>
        NVAPI_REQUEST_PENDING = -230,
        /// <summary>
        /// Operation cannot be performed because the resource is in use.
        /// </summary>
        NVAPI_RESOURCE_IN_USE = -231
    }

    public enum NVDRS_SETTING_TYPE: uint
    {
        NVDRS_DWORD_TYPE,
        NVDRS_BINARY_TYPE,
        NVDRS_STRING_TYPE,
        NVDRS_WSTRING_TYPE
    }

    public enum ESetting : uint
    {
        OGL_AA_LINE_GAMMA_ID = 0x2089BF6C,
        OGL_DEEP_COLOR_SCANOUT_ID = 0x2097C2F6,
        OGL_DEFAULT_SWAP_INTERVAL_ID = 0x206A6582,
        OGL_DEFAULT_SWAP_INTERVAL_FRACTIONAL_ID = 0x206C4581,
        OGL_DEFAULT_SWAP_INTERVAL_SIGN_ID = 0x20655CFA,
        OGL_EVENT_LOG_SEVERITY_THRESHOLD_ID = 0x209DF23E,
        OGL_EXTENSION_STRING_VERSION_ID = 0x20FF7493,
        OGL_FORCE_BLIT_ID = 0x201F619F,
        OGL_FORCE_STEREO_ID = 0x204D9A0C,
        OGL_IMPLICIT_GPU_AFFINITY_ID = 0x20D0F3E6,
        OGL_MAX_FRAMES_ALLOWED_ID = 0x208E55E3,
        OGL_MULTIMON_ID = 0x200AEBFC,
        OGL_OVERLAY_PIXEL_TYPE_ID = 0x209AE66F,
        OGL_OVERLAY_SUPPORT_ID = 0x206C28C4,
        OGL_QUALITY_ENHANCEMENTS_ID = 0x20797D6C,
        OGL_SINGLE_BACKDEPTH_BUFFER_ID = 0x20A29055,
        OGL_THREAD_CONTROL_ID = 0x20C1221E,
        OGL_TRIPLE_BUFFER_ID = 0x20FDD1F9,
        OGL_VIDEO_EDITING_MODE_ID = 0x20EE02B4,
        AA_BEHAVIOR_FLAGS_ID = 0x10ECDB82,
        AA_MODE_ALPHATOCOVERAGE_ID = 0x10FC2D9C,
        AA_MODE_GAMMACORRECTION_ID = 0x107D639D,
        AA_MODE_METHOD_ID = 0x10D773D2,
        AA_MODE_REPLAY_ID = 0x10D48A85,
        AA_MODE_SELECTOR_ID = 0x107EFC5B,
        AA_MODE_SELECTOR_SLIAA_ID = 0x107AFC5B,
        ANISO_MODE_LEVEL_ID = 0x101E61A9,
        ANISO_MODE_SELECTOR_ID = 0x10D2BB16,
        APPLICATION_PROFILE_NOTIFICATION_TIMEOUT_ID = 0x104554B6,
        APPLICATION_STEAM_ID_ID = 0x107CDDBC,
        CPL_HIDDEN_PROFILE_ID = 0x106D5CFF,
        CUDA_EXCLUDED_GPUS_ID = 0x10354FF8,
        D3DOGL_GPU_MAX_POWER_ID = 0x10D1EF29,
        EXPORT_PERF_COUNTERS_ID = 0x108F0841,
        FXAA_ALLOW_ID = 0x1034CB89,
        FXAA_ENABLE_ID = 0x1074C972,
        FXAA_INDICATOR_ENABLE_ID = 0x1068FB9C,
        MCSFRSHOWSPLIT_ID = 0x10287051,
        OPTIMUS_MAXAA_ID = 0x10F9DC83,
        PHYSXINDICATOR_ID = 0x1094F16F,
        PREFERRED_PSTATE_ID = 0x1057EB71,
        PREVENT_UI_AF_OVERRIDE_ID = 0x103BCCB5,
        PS_FRAMERATE_LIMITER_ID = 0x10834FEE,
        PS_FRAMERATE_LIMITER_GPS_CTRL_ID = 0x10834F01,
        PS_FRAMERATE_MONITOR_CTRL_ID = 0x10834F05,
        SHIM_MAXRES_ID = 0x10F9DC82,
        SHIM_MCCOMPAT_ID = 0x10F9DC80,
        SHIM_RENDERING_MODE_ID = 0x10F9DC81,
        SHIM_RENDERING_OPTIONS_ID = 0x10F9DC84,
        SLI_GPU_COUNT_ID = 0x1033DCD1,
        SLI_PREDEFINED_GPU_COUNT_ID = 0x1033DCD2,
        SLI_PREDEFINED_GPU_COUNT_DX10_ID = 0x1033DCD3,
        SLI_PREDEFINED_MODE_ID = 0x1033CEC1,
        SLI_PREDEFINED_MODE_DX10_ID = 0x1033CEC2,
        SLI_RENDERING_MODE_ID = 0x1033CED1,
        VRPRERENDERLIMIT_ID = 0x10111133,
        VRRFEATUREINDICATOR_ID = 0x1094F157,
        VRROVERLAYINDICATOR_ID = 0x1095F16F,
        VRRREQUESTSTATE_ID = 0x1094F1F7,
        VSYNCSMOOTHAFR_ID = 0x101AE763,
        VSYNCVRRCONTROL_ID = 0x10A879CE,
        VSYNC_BEHAVIOR_FLAGS_ID = 0x10FDEC23,
        WKS_API_STEREO_EYES_EXCHANGE_ID = 0x11AE435C,
        WKS_API_STEREO_MODE_ID = 0x11E91A61,
        WKS_MEMORY_ALLOCATION_POLICY_ID = 0x11112233,
        WKS_STEREO_DONGLE_SUPPORT_ID = 0x112493BD,
        WKS_STEREO_SUPPORT_ID = 0x11AA9E99,
        WKS_STEREO_SWAP_MODE_ID = 0x11333333,
        AO_MODE_ID = 0x00667329,
        AO_MODE_ACTIVE_ID = 0x00664339,
        AUTO_LODBIASADJUST_ID = 0x00638E8F,
        ICAFE_LOGO_CONFIG_ID = 0x00DB1337,
        LODBIASADJUST_ID = 0x00738E8F,
        MAXWELL_B_SAMPLE_INTERLEAVE_ID = 0x0098C1AC,
        PRERENDERLIMIT_ID = 0x007BA09E,
        PS_SHADERDISKCACHE_ID = 0x00198FFF,
        PS_TEXFILTER_ANISO_OPTS2_ID = 0x00E73211,
        PS_TEXFILTER_BILINEAR_IN_ANISO_ID = 0x0084CD70,
        PS_TEXFILTER_DISABLE_TRILIN_SLOPE_ID = 0x002ECAF2,
        PS_TEXFILTER_NO_NEG_LODBIAS_ID = 0x0019BB68,
        QUALITY_ENHANCEMENTS_ID = 0x00CE2691,
        REFRESH_RATE_OVERRIDE_ID = 0x0064B541,
        SET_POWER_THROTTLE_FOR_PCIe_COMPLIANCE_ID = 0x00AE785C,
        SET_VAB_DATA_ID = 0x00AB8687,
        VSYNCMODE_ID = 0x00A879CF,
        VSYNCTEARCONTROL_ID = 0x005A375C,
        TOTAL_DWORD_SETTING_NUM = 82,
        TOTAL_WSTRING_SETTING_NUM = 4,
        TOTAL_SETTING_NUM = 86,
        INVALID_SETTING_ID = 0xFFFFFFFF
    };

    public enum NVDRS_SETTING_LOCATION : uint
    {
        NVDRS_CURRENT_PROFILE_LOCATION,
        NVDRS_GLOBAL_PROFILE_LOCATION,
        NVDRS_BASE_PROFILE_LOCATION
    }

    public enum EValues_SHIM_MCCOMPAT: uint
    { 
        SHIM_MCCOMPAT_INTEGRATED = 0x00000000,
        SHIM_MCCOMPAT_ENABLE = 0x00000001,
        SHIM_MCCOMPAT_USER_EDITABLE = 0x00000002,
        SHIM_MCCOMPAT_MASK = 0x00000003,
        SHIM_MCCOMPAT_VIDEO_MASK = 0x00000004,
        SHIM_MCCOMPAT_VARYING_BIT = 0x00000008,
        SHIM_MCCOMPAT_AUTO_SELECT = 0x00000010,
        SHIM_MCCOMPAT_OVERRIDE_BIT = 0x80000000,
        SHIM_MCCOMPAT_NUM_VALUES = 8,
        SHIM_MCCOMPAT_DEFAULT = SHIM_MCCOMPAT_AUTO_SELECT
    };

    public enum EValues_SHIM_RENDERING_MODE : uint
    {
        SHIM_RENDERING_MODE_INTEGRATED = 0x00000000,
        SHIM_RENDERING_MODE_ENABLE = 0x00000001,
        SHIM_RENDERING_MODE_USER_EDITABLE = 0x00000002,
        SHIM_RENDERING_MODE_MASK = 0x00000003,
        SHIM_RENDERING_MODE_VIDEO_MASK = 0x00000004,
        SHIM_RENDERING_MODE_VARYING_BIT = 0x00000008,
        SHIM_RENDERING_MODE_AUTO_SELECT = 0x00000010,
        SHIM_RENDERING_MODE_OVERRIDE_BIT = 0x80000000,
        SHIM_RENDERING_MODE_NUM_VALUES = 8,
        SHIM_RENDERING_MODE_DEFAULT = SHIM_RENDERING_MODE_AUTO_SELECT
    };

    public enum EValues_SHIM_RENDERING_OPTIONS : uint
    {
        SHIM_RENDERING_OPTIONS_DEFAULT_RENDERING_MODE = 0x00000000,
        SHIM_RENDERING_OPTIONS_DISABLE_ASYNC_PRESENT = 0x00000001,
        SHIM_RENDERING_OPTIONS_EHSHELL_DETECT = 0x00000002,
        SHIM_RENDERING_OPTIONS_FLASHPLAYER_HOST_DETECT = 0x00000004,
        SHIM_RENDERING_OPTIONS_VIDEO_DRM_APP_DETECT = 0x00000008,
        SHIM_RENDERING_OPTIONS_IGNORE_OVERRIDES = 0x00000010,
        SHIM_RENDERING_OPTIONS_CHILDPROCESS_DETECT = 0x00000020,
        SHIM_RENDERING_OPTIONS_ENABLE_DWM_ASYNC_PRESENT = 0x00000040,
        SHIM_RENDERING_OPTIONS_PARENTPROCESS_DETECT = 0x00000080,
        SHIM_RENDERING_OPTIONS_ALLOW_INHERITANCE = 0x00000100,
        SHIM_RENDERING_OPTIONS_DISABLE_WRAPPERS = 0x00000200,
        SHIM_RENDERING_OPTIONS_DISABLE_DXGI_WRAPPERS = 0x00000400,
        SHIM_RENDERING_OPTIONS_PRUNE_UNSUPPORTED_FORMATS = 0x00000800,
        SHIM_RENDERING_OPTIONS_ENABLE_ALPHA_FORMAT = 0x00001000,
        SHIM_RENDERING_OPTIONS_IGPU_TRANSCODING = 0x00002000,
        SHIM_RENDERING_OPTIONS_DISABLE_CUDA = 0x00004000,
        SHIM_RENDERING_OPTIONS_ALLOW_CP_CAPS_FOR_VIDEO = 0x00008000,
        SHIM_RENDERING_OPTIONS_ENABLE_NEW_HOOKING = 0x00010000,
        SHIM_RENDERING_OPTIONS_DISABLE_DURING_SECURE_BOOT = 0x00020000,
        SHIM_RENDERING_OPTIONS_INVERT_FOR_QUADRO = 0x00040000,
        SHIM_RENDERING_OPTIONS_INVERT_FOR_MSHYBRID = 0x00080000,
        SHIM_RENDERING_OPTIONS_REGISTER_PROCESS_ENABLE_GOLD = 0x00100000,
        SHIM_RENDERING_OPTIONS_HANDLE_WINDOWED_MODE_PERF_OPT = 0x00200000,
        SHIM_RENDERING_OPTIONS_NUM_VALUES = 23,
        SHIM_RENDERING_OPTIONS_DEFAULT = SHIM_RENDERING_OPTIONS_DEFAULT_RENDERING_MODE
    };
}
