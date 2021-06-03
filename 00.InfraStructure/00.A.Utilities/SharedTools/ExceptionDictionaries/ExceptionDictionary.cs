namespace Utilities.SharedTools.ExceptionDictionaries
{
    public enum ExceptionCodes
    {
        //todo: this enum should be break down to separate enums for each below code regions

        #region Unknown
        UnknownException = 0
        #endregion

        #region DomainExceptionCodes                        
        , UserAccountingDomainRoleTitle = 10001               //"Role Title Should be Cannot be Empty or with only white space or More than 100 characters.";
        , UserAccountingDomainRoleDescription = 10002        //"Description Cannot be Empty or with only white space or More than 500 characters.";
        , UserAccountingDomainRoleSystemDescription = 10003 // "SystemDescription Cannot be Empty or with only white space or More than 400 characters.";

        , UserAccountingDomainPositionTitle = 10005         //"Position Title Cannot be Empty or with only white space or Not be More than 100 characters."
        , UserAccountingDomainPositionCode = 10006          //"Position Code Cannot be Empty or with only white space or Not be More than 50 characters and should contain only digits."
        , UserAccountingDomainPositionCustomsCode = 10007     //"Position CustomesCode Cannot be white space or Not be More than 50 characters and should contain only digits."
        , UserAccountingDomainPositionDescription = 10008     //"Position Description Cannot be white space or Not be More than 200 Characters."
        , UserAccountingDomainPositionDamageType = 10009      //"Position DamageType has not a valid value."
        , UserAccountingDomainPositionErgonomicType = 10010  // "Position ErgonomicStatus has not a valid value."


        #endregion

        #region ApiExceptionCodes
          , UserAccountingApiRoleCreatePostNullException = 600001
        , UserAccountingApiRoleCreateGet = 600002
        , UserAccountingApiRoleCreatePost = 600003
        , UserAccountingApiRoleEditGet = 600004
        , UserAccountingApiRoleEditPost = 600005
        , UserAccountingApiRoleDeleteGet_NotFound = 600006
        , UserAccountingApiRoleDeletePost = 600007 
        , UserAccountingApiRoleDeleteByIdPost = 600008 
        #endregion
    }
}
