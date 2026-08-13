using Core.Entities.OrderAggregate;

namespace Core.Specifications;

public class OrderSpecification : BaseSpecification<Order>
{
    public OrderSpecification(string email) : base(o => o.BuyerEmail == email)
    {
        AddInclude(x => x.OrderItems);
        AddInclude(x => x.DeliveryMethod);
        AddOrderByDescending(x => x.OrderDate);
    }
 
    public OrderSpecification(string email, int id) : base(o => o.BuyerEmail == email && o.Id == id)
    {
        AddInclude("OrderItems");
        AddInclude("DeliveryMethod");
    }

    public OrderSpecification(string paymentIntentId, bool isPaymentIntent): 
        base(x => x.PaymentIntentId == paymentIntentId)
    {
        AddInclude("OrderItems");
        AddInclude("DeliveryMethod");
    }
}