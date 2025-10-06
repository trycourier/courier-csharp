using Courier.Core;
using StepProperties = Courier.Models.Automations.Invoke.InvokeInvokeAdHocParamsProperties.AutomationProperties.StepProperties;

namespace Courier.Models.Automations.Invoke.InvokeInvokeAdHocParamsProperties.AutomationProperties.StepVariants;

public sealed record class AutomationDelayStep(StepProperties::AutomationDelayStep Value)
    : Step,
        IVariant<AutomationDelayStep, StepProperties::AutomationDelayStep>
{
    public static AutomationDelayStep From(StepProperties::AutomationDelayStep value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class AutomationSendStep(StepProperties::AutomationSendStep Value)
    : Step,
        IVariant<AutomationSendStep, StepProperties::AutomationSendStep>
{
    public static AutomationSendStep From(StepProperties::AutomationSendStep value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class AutomationSendListStep(StepProperties::AutomationSendListStep Value)
    : Step,
        IVariant<AutomationSendListStep, StepProperties::AutomationSendListStep>
{
    public static AutomationSendListStep From(StepProperties::AutomationSendListStep value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class AutomationUpdateProfileStep(
    StepProperties::AutomationUpdateProfileStep Value
) : Step, IVariant<AutomationUpdateProfileStep, StepProperties::AutomationUpdateProfileStep>
{
    public static AutomationUpdateProfileStep From(
        StepProperties::AutomationUpdateProfileStep value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class AutomationCancelStep(StepProperties::AutomationCancelStep Value)
    : Step,
        IVariant<AutomationCancelStep, StepProperties::AutomationCancelStep>
{
    public static AutomationCancelStep From(StepProperties::AutomationCancelStep value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class AutomationFetchDataStep(StepProperties::AutomationFetchDataStep Value)
    : Step,
        IVariant<AutomationFetchDataStep, StepProperties::AutomationFetchDataStep>
{
    public static AutomationFetchDataStep From(StepProperties::AutomationFetchDataStep value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class AutomationInvokeStep(StepProperties::AutomationInvokeStep Value)
    : Step,
        IVariant<AutomationInvokeStep, StepProperties::AutomationInvokeStep>
{
    public static AutomationInvokeStep From(StepProperties::AutomationInvokeStep value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
