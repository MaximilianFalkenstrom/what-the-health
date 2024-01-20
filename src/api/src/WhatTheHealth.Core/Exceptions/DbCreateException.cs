namespace WhatTheHealth.Core.Exceptions;

public class DbCreateException : Exception
{
    public DbCreateException()
    {

    }

    public DbCreateException(string message) : base(message)
    {
    }

    public DbCreateException(string message, Exception inner) : base(message, inner)
    {
    }
}
