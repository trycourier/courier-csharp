using Courier.Core;

namespace Courier.Models.Automations.Invoke.InvokeInvokeAdHocParamsProperties.AutomationProperties.StepProperties.AutomationAddToBatchStepProperties.IntersectionMember1Properties.MaxItemsVariants;

public sealed record class String(string Value) : MaxItems, IVariant<String, string>
{
    public static String From(string value)
    {
        return new(value);
    }

    public override void Validate() { }
}

public sealed record class Long(long Value) : MaxItems, IVariant<Long, long>
{
    public static Long From(long value)
    {
        return new(value);
    }

    public override void Validate() { }
}
