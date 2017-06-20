using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using eWineryClass.eWineryWS;
using System.Web.Services;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using System.Text;
using System.Xml.Linq;
using System.Data.Linq;
using System.Linq;
public partial class StoredProcedures
{
    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void eWinery_GetWineryStates(SqlString UserName, SqlString Password, SqlString PartnerID, out SqlXml ReturnWineryStates)
    {

        eWineryClass.eWineryWS.EWSWebServices webServices = new eWineryClass.eWineryWS.EWSWebServices();
        eWineryClass.eWineryWS.GetWineryStatesRequest WineryStatesRequest = new eWineryClass.eWineryWS.GetWineryStatesRequest();
        WineryStatesRequest.Username = Convert.ToString(UserName);
        WineryStatesRequest.Password = Convert.ToString(Password);
        WineryStatesRequest.PartnerKeyID = new Guid(Convert.ToString(PartnerID));
        eWineryClass.eWineryWS.GetWineryStatesResponse WineryStatesResponse = webServices.GetWineryStates(WineryStatesRequest);
        XmlDocument LoadXml = new XmlDocument();
        LoadXml.LoadXml(SerializeAndDisplay(WineryStatesResponse));
        LoadXml = RemoveXmlns(LoadXml);
        ReturnWineryStates = ConvertStringToXML(LoadXml.InnerXml);
    }
    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void eWinery_GetWineryMemberTypes(SqlString UserName, SqlString Password, SqlString PartnerID, SqlString WineryID, out SqlXml ReturnWineryMemberTypes)
    {
        eWineryClass.eWineryWS.EWSWebServices webServices = new eWineryClass.eWineryWS.EWSWebServices();
        eWineryClass.eWineryWS.GetWineryMemberTypesRequest WineryMemberTypesRequest = new eWineryClass.eWineryWS.GetWineryMemberTypesRequest();
        WineryMemberTypesRequest.Username = Convert.ToString(UserName);
        WineryMemberTypesRequest.Password = Convert.ToString(Password);
        WineryMemberTypesRequest.PartnerKeyID = new Guid(Convert.ToString(PartnerID));
        WineryMemberTypesRequest.WineryID = new Guid(Convert.ToString(WineryID));

        eWineryClass.eWineryWS.GetWineryMemberTypesResponse WineryMemberTypesResponse = webServices.GetWineryMemberTypes(WineryMemberTypesRequest);
        XmlDocument LoadXml = new XmlDocument();
        LoadXml.LoadXml(SerializeAndDisplay(WineryMemberTypesResponse));
        LoadXml = RemoveXmlns(LoadXml);
        ReturnWineryMemberTypes = ConvertStringToXML(LoadXml.InnerXml);
    }
    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void eWinery_GetProducts(SqlString UserName, SqlString Password, SqlString PartnerID, SqlString WineryID, out SqlXml ReturnProducts)
    {

        eWineryClass.eWineryWS.EWSWebServices webServices = new eWineryClass.eWineryWS.EWSWebServices();
        eWineryClass.eWineryWS.GetProductsRequest productRequest = new eWineryClass.eWineryWS.GetProductsRequest();
        productRequest.Username = Convert.ToString(UserName);
        productRequest.Password = Convert.ToString(Password);
        productRequest.PartnerKeyID = new Guid(Convert.ToString(PartnerID));
        productRequest.WineryID = new Guid(Convert.ToString(WineryID));
        productRequest.IncludeProductCategories = true;
        productRequest.IncludeProductInformationPages = true;
        productRequest.IncludeProductPrices = true;

        eWineryClass.eWineryWS.GetProductsResponse productResponse = webServices.GetProducts(productRequest);

        XmlDocument LoadXml = new XmlDocument();
        LoadXml.LoadXml(SerializeAndDisplay(productResponse));
        LoadXml = RemoveXmlns(LoadXml);
        ReturnProducts = ConvertStringToXML(LoadXml.InnerXml);
        
    }

    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void eWinery_GetMembers(SqlString UserName, SqlString Password, SqlString PartnerID, SqlString WineryID, SqlDateTime FromDateTime, SqlDateTime ToDateTime,  out SqlXml ReturnMembers)
    {
        eWineryClass.eWineryWS.EWSWebServices webServices = new eWineryClass.eWineryWS.EWSWebServices();
        eWineryClass.eWineryWS.GetMembersRequest MembersRequest = new eWineryClass.eWineryWS.GetMembersRequest();
        MembersRequest.Username = Convert.ToString(UserName);
        MembersRequest.Password = Convert.ToString(Password);
        MembersRequest.PartnerKeyID = new Guid(Convert.ToString(PartnerID));
        MembersRequest.WineryID = new Guid(Convert.ToString(WineryID));
        MembersRequest.DateModifiedFrom = FromDateTime.Value;
        MembersRequest.DateModifiedTo = ToDateTime.Value;
        eWineryClass.eWineryWS.GetMembersResponse MembersResponse = webServices.GetMembers(MembersRequest);
        

        XmlDocument LoadXml = new XmlDocument();
        LoadXml.LoadXml(SerializeAndDisplay(MembersResponse));
        LoadXml = RemoveXmlns(LoadXml);
        ReturnMembers = ConvertStringToXML(LoadXml.InnerXml);
    }


    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void eWinery_Test(SqlDateTime FromDateTime, out SqlString ReturnValue, out SqlString ReturnMember, DateTime timetest, out datetime timetestout)
    {
    
        ReturnValue = Convert.ToString(FromDateTime.Value);
        eWineryClass.eWineryWS.EWSWebServices webServices = new eWineryClass.eWineryWS.EWSWebServices();
        eWineryClass.eWineryWS.GetMembersRequest MembersRequest = new eWineryClass.eWineryWS.GetMembersRequest();
        MembersRequest.DateModifiedFrom = Convert.ToDateTime(FromDateTime.Value);
        ReturnMember = MembersRequest.DateModifiedFrom.ToString();
        timetest = Convert.ToDateTime("01/01/1970");
    }
    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void eWinery_GetClubs(SqlString UserName, SqlString Password, SqlString PartnerID, SqlString WineryID, out SqlXml ReturnClubs)
    {

        eWineryClass.eWineryWS.EWSWebServices webServices = new eWineryClass.eWineryWS.EWSWebServices();
        eWineryClass.eWineryWS.GetClubsRequest ClubsRequest = new eWineryClass.eWineryWS.GetClubsRequest();
        ClubsRequest.Username = Convert.ToString(UserName);
        ClubsRequest.Password = Convert.ToString(Password);
        ClubsRequest.PartnerKeyID = new Guid(Convert.ToString(PartnerID));

        eWineryClass.eWineryWS.GetClubsResponse ClubsResponse = webServices.GetClubs(ClubsRequest);

        XmlDocument LoadXml = new XmlDocument();
        LoadXml.LoadXml(SerializeAndDisplay(ClubsResponse));
        LoadXml = RemoveXmlns(LoadXml);
        ReturnClubs = ConvertStringToXML(LoadXml.InnerXml);

    }
    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void eWinery_GetCompliantWines(SqlString UserName, SqlString Password, SqlString PartnerID, out SqlXml ReturnCompliantWines)
    {

        eWineryClass.eWineryWS.EWSWebServices webServices = new eWineryClass.eWineryWS.EWSWebServices();
        eWineryClass.eWineryWS.GetCompliantWinesRequest CompliantWinesRequest = new eWineryClass.eWineryWS.GetCompliantWinesRequest();
        CompliantWinesRequest.Username = Convert.ToString(UserName);
        CompliantWinesRequest.Password = Convert.ToString(Password);
        CompliantWinesRequest.PartnerKeyID = new Guid(Convert.ToString(PartnerID));

        eWineryClass.eWineryWS.GetCompliantWinesResponse CompliantWinesResponse = webServices.GetCompliantWines(CompliantWinesRequest);

        XmlDocument LoadXml = new XmlDocument();
        LoadXml.LoadXml(SerializeAndDisplay(CompliantWinesResponse));
        LoadXml = RemoveXmlns(LoadXml);
        ReturnCompliantWines = ConvertStringToXML(LoadXml.InnerXml);

    }
    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void eWinery_GetMemberClubsAndTypes(SqlString UserName, SqlString Password, SqlString PartnerID, out SqlXml ReturnMemberClubsAndTypes)
    {

        eWineryClass.eWineryWS.EWSWebServices webServices = new eWineryClass.eWineryWS.EWSWebServices();
        eWineryClass.eWineryWS.GetMemberClubsAndTypesRequest MemberClubsAndTypesRequest = new eWineryClass.eWineryWS.GetMemberClubsAndTypesRequest();
        MemberClubsAndTypesRequest.Username = Convert.ToString(UserName);
        MemberClubsAndTypesRequest.Password = Convert.ToString(Password);
        MemberClubsAndTypesRequest.PartnerKeyID = new Guid(Convert.ToString(PartnerID));

        eWineryClass.eWineryWS.GetMemberClubsAndTypesResponse ClubsAndTypesResponse = webServices.GetMemberClubsAndTypes(MemberClubsAndTypesRequest);

        XmlDocument LoadXml = new XmlDocument();
        LoadXml.LoadXml(SerializeAndDisplay(ClubsAndTypesResponse));
        LoadXml = RemoveXmlns(LoadXml);
        ReturnMemberClubsAndTypes = ConvertStringToXML(LoadXml.InnerXml);

    }
    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void eWinery_GetWineBrands(SqlString UserName, SqlString Password, SqlString PartnerID, out SqlXml ReturnWineBrands)
    {

        eWineryClass.eWineryWS.EWSWebServices webServices = new eWineryClass.eWineryWS.EWSWebServices();
        eWineryClass.eWineryWS.GetWineBrandsRequest WineBrandsRequest = new eWineryClass.eWineryWS.GetWineBrandsRequest();
        WineBrandsRequest.Username = Convert.ToString(UserName);
        WineBrandsRequest.Password = Convert.ToString(Password);
        WineBrandsRequest.PartnerKeyID = new Guid(Convert.ToString(PartnerID));

        eWineryClass.eWineryWS.GetWineBrandsResponse WineBrandsResponse = webServices.GetWineBrands(WineBrandsRequest);

        XmlDocument LoadXml = new XmlDocument();
        LoadXml.LoadXml(SerializeAndDisplay(WineBrandsResponse));
        LoadXml = RemoveXmlns(LoadXml);
        ReturnWineBrands = ConvertStringToXML(LoadXml.InnerXml);

    }
    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void eWinery_GetWines(SqlString UserName, SqlString Password, SqlString PartnerID, out SqlXml ReturnWines)
    {
        eWineryClass.eWineryWS.EWSWebServices webServices = new eWineryClass.eWineryWS.EWSWebServices();
        eWineryClass.eWineryWS.GetWinesRequest WinesRequest = new eWineryClass.eWineryWS.GetWinesRequest();
        WinesRequest.Username = Convert.ToString(UserName);
        WinesRequest.Password = Convert.ToString(Password);
        WinesRequest.PartnerKeyID = new Guid(Convert.ToString(PartnerID));

        eWineryClass.eWineryWS.GetWinesResponse WinesResponse = webServices.GetWines(WinesRequest);

        XmlDocument LoadXml = new XmlDocument();
        LoadXml.LoadXml(SerializeAndDisplay(WinesResponse));
        LoadXml = RemoveXmlns(LoadXml);
        ReturnWines = ConvertStringToXML(LoadXml.InnerXml); 
    }
    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void eWinery_GetWinesGlobal(SqlString UserName, SqlString Password, SqlString PartnerID, SqlString WineryID, out SqlXml ReturnWinesGlobal)
    {

        eWineryClass.eWineryWS.EWSWebServices webServices = new eWineryClass.eWineryWS.EWSWebServices();
        eWineryClass.eWineryWS.GetWinesGlobalRequest WinesGlobalRequest = new eWineryClass.eWineryWS.GetWinesGlobalRequest();
        WinesGlobalRequest.Username = Convert.ToString(UserName);
        WinesGlobalRequest.Password = Convert.ToString(Password);
        WinesGlobalRequest.PartnerKeyID = new Guid(Convert.ToString(PartnerID));
        WinesGlobalRequest.WineryID = new Guid(Convert.ToString(WineryID));

        eWineryClass.eWineryWS.GetWinesGlobalResponse WinesGlobalResponse = webServices.GetWinesGlobal(WinesGlobalRequest);

        XmlDocument LoadXml = new XmlDocument();
        LoadXml.LoadXml(SerializeAndDisplay(WinesGlobalResponse));
        LoadXml = RemoveXmlns(LoadXml);
        ReturnWinesGlobal = ConvertStringToXML(LoadXml.InnerXml);

    }
    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void eWinery_GetProductCategories(SqlString UserName, SqlString Password, SqlString PartnerID, SqlString WineryID, out SqlXml ReturnProductCategories)
    {

        eWineryClass.eWineryWS.EWSWebServices webServices = new eWineryClass.eWineryWS.EWSWebServices();
        eWineryClass.eWineryWS.GetProductCategoriesRequest ProductCategoriesRequest = new eWineryClass.eWineryWS.GetProductCategoriesRequest();
        ProductCategoriesRequest.Username = Convert.ToString(UserName);
        ProductCategoriesRequest.Password = Convert.ToString(Password);
        ProductCategoriesRequest.PartnerKeyID = new Guid(Convert.ToString(PartnerID));
        ProductCategoriesRequest.WineryID = new Guid(Convert.ToString(WineryID));

        eWineryClass.eWineryWS.GetProductCategoriesResponse ProductCategoriesResponse = webServices.GetProductCategories(ProductCategoriesRequest);

        XmlDocument LoadXml = new XmlDocument();
        LoadXml.LoadXml(SerializeAndDisplay(ProductCategoriesResponse));
        LoadXml = RemoveXmlns(LoadXml);
        ReturnProductCategories = ConvertStringToXML(LoadXml.InnerXml);

    }
    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void eWinery_GetOrders(SqlString UserName, SqlString Password, SqlString PartnerID, SqlString WineryID, SqlDateTime FromDateTime, SqlDateTime ToDateTime, out SqlXml ReturnOrders)
    {

        eWineryClass.eWineryWS.EWSWebServices webServices = new eWineryClass.eWineryWS.EWSWebServices();
        eWineryClass.eWineryWS.GetOrdersRequest OrderRequest = new eWineryClass.eWineryWS.GetOrdersRequest();
        OrderRequest.Username = Convert.ToString(UserName);
        OrderRequest.Password = Convert.ToString(Password);
        OrderRequest.PartnerKeyID = new Guid(Convert.ToString(PartnerID));
        OrderRequest.WineryID = new Guid(Convert.ToString(WineryID));
        OrderRequest.DateModifiedFrom = FromDateTime.Value;
        OrderRequest.DateModifiedTo = ToDateTime.Value;

        eWineryClass.eWineryWS.GetOrdersResponse OrdersResponse = webServices.GetOrders(OrderRequest);

        XmlDocument LoadXml = new XmlDocument();
        LoadXml.LoadXml(SerializeAndDisplay(OrdersResponse));
        LoadXml = RemoveXmlns(LoadXml);
        ReturnOrders = ConvertStringToXML(LoadXml.InnerXml);

    }

    private static System.Data.SqlTypes.SqlXml ConvertStringToXML(string xmlData)
    {
        System.Data.SqlTypes.SqlXml objData;
        try
        {
            objData = new System.Data.SqlTypes.SqlXml(new System.Xml.XmlTextReader(xmlData, System.Xml.XmlNodeType.Document, null));
        }
        catch
        {
            throw;
        }
        return objData;
    }
    private static XmlDocument RemoveXmlns(XmlDocument doc)
    {
        XDocument d;
        using (var nodeReader = new XmlNodeReader(doc))
            d = XDocument.Load(nodeReader);

        d.Root.Descendants().Attributes().Where(x => x.IsNamespaceDeclaration).Remove();

        foreach (var elem in d.Descendants())
            elem.Name = elem.Name.LocalName;

        var xmlDocument = new XmlDocument();
        using (var xmlReader = d.CreateReader())
            xmlDocument.Load(xmlReader);

        return xmlDocument;
    }
    private static string SerializeAndDisplay(Object response)
    {
        Type objType = response.GetType();
        StringWriter textWriter = new StringWriter();
        XmlSerializer serializer = new XmlSerializer(objType);
        serializer.Serialize(textWriter, response);
        return textWriter.ToString();
    }
}
