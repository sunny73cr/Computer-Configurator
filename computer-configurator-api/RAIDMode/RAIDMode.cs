﻿namespace ComputerConfigurator.Api.RAIDMode;

public partial class RAIDMode
{
    public Guid UUID { get; set; }
    public string Mode { get; set; } = string.Empty;

    public RAIDMode()
    {

    }

    public RAIDMode(DTO.Create RAIDMode)
    {
        UUID = RAIDMode.UUID;
        Mode = RAIDMode.Mode;
    }

    public static void Edit(RAIDMode RAIDMode, DTO.Edit edits)
    {
        if (RAIDMode.Mode != edits.Mode) RAIDMode.Mode = edits.Mode;
    }
}
