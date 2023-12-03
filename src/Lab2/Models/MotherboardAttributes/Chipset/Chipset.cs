using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.MotherboardAttributes.Chipset;

public record Chipset(IReadOnlyList<int> SupportedFrequencies, bool SupportXmp);