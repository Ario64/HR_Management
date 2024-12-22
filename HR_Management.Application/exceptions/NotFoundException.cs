﻿namespace HR_Management.Application.exceptions;

public class NotFoundException : ApplicationException
{
    public NotFoundException(string name, object key) : base($"{name} ({key}) was not found.")
    {

    }
}