namespace WhatTheHealth.Core.Exceptions;

public class DbNotFoundException : Exception
{
    public DbNotFoundException()
    {

    }

    public DbNotFoundException(string message) : base(message)
    {
    }

    public DbNotFoundException(string message, Exception inner) : base(message, inner)
    {
    }
}
