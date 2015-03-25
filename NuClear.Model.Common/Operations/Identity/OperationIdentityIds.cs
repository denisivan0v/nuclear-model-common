using System;

namespace NuClear.Model.Common.Operations.Identity
{
    public static class OperationIdentityIds
    {
        // generic operations
        public const int ActionHistoryIdentity = 1;
        public const int ActivateIdentity = 2;
        public const int AppendIdentity = 3;
        public const int AssignIdentity = 4;
        public const int ChangeClientIdentity = 5;
        public const int ChangeTerritoryIdentity = 6;
        public const int CheckForDebtsIdentity = 7;
        public const int DeactivateIdentity = 8;
        public const int DeleteIdentity = 9;
        public const int DisqualifyIdentity = 10;
        public const int DownloadIdentity = 11;
        public const int UploadIdentity = 12;
        public const int GetDomainEntityDtoIdentity = 13;
        public const int ModifyBusinessModelEntityIdentity = 14;
        public const int ListIdentity = 15;
        public const int QualifyIdentity = 16;
        public const int ListNonGenericIdentity = 19;
        public const int ModifySimplifiedModelEntityIdentity = 20;
        public const int ExportIdentity = 22;

        [Obsolete("CreateIdentity or UpdateIdentity must be used")]
        public const int CreateOrUpdateIdentity = 23;

        [Obsolete("CopyOrderIdentity or CopyPriceIdentity must be used")]
        public const int CopyIdentity = 24;

        public const int MergeIdentity = 25;
        public const int SetAsDefaultThemeIdentity = 29;
        public const int CreateIdentity = 30;
        public const int UpdateIdentity = 31;
        public const int DetachIdentity = 34;
        public const int MsCrmExportIdentity = 35;
        public const int PrintIdentity = 36;
        public const int BulkDeactivateIdentity = 37;
        public const int BulkActivateIdentity = 38;
        public const int BulkCreateIdentity = 39;
        public const int BulkDeleteIdentity = 40;
        public const int BulkUpdateIdentity = 41;

        public const int CancelIdentity = 1042;
        public const int CompleteIdentity = 1043;
        public const int ReopenIdentity = 1044;
    }
}
