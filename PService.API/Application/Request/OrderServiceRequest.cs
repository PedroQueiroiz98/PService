namespace PService.API;


public class OrderServiceRequest{

    public int CustomerId {get;set;}
    public DateTime OrderDate {get;set;}
    public string ServiceName {get;set;} = "";
    public string ServiceDescription {get;set;} = "";

}

