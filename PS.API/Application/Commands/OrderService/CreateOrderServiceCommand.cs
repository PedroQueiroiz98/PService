using System.Runtime.Serialization;
using MediatR;

namespace PS.API.Application.Commands.OrderService;


[DataContract]
public class CreateOrderServiceCommand : IRequest<bool>{

    [DataMember]
    public int CustomerId { get; private set; }
    [DataMember]
    public int ServiceId { get; private set; }
    [DataMember]
    public int ProblemId { get; private set; }
    [DataMember]
    public int ProblemDescription { get; private set; }

    public CreateOrderServiceCommand(int customerId,int serviceId, int problemId, string problemDescription){

        CustomerId = customerId;
        ServiceId = serviceId;
        ProblemId = problemId;
        ProblemDescription = ProblemDescription;
    }

}