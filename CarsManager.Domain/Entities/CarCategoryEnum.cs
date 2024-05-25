using System.ComponentModel;

namespace CarsManager.Domain.Entities;
public enum CarCategoryEnum
{
    [Description("Hatchback Car")]
    Hatchback = 1,
    [Description("SUV Car")]
    SUV = 2,
    [Description("Sport Car")]
    Sport = 3,
    [Description("Other")]
    Other = 4
}
