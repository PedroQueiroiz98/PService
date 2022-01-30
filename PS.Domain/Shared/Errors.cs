namespace PS.Domain.Shared;


public static class DomainErrors{


    public static class OrderServiceErrors{


        public static string RequiredProduct()=>"Nenhum produto requirido foi informado";
        public static string RequiredCustomer()=>"Cliente não informado";
        public static string RequiredServiceName()=>"Nome do serviço não informado";
        public static string RequiredServiceDescription()=>"Descrição do serviço não informado";
        public static string RequiredResponseTime()=>"Tempo de resposta não informado";



    }


}