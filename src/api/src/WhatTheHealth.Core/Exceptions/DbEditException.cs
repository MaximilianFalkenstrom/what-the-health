namespace WhatTheHealth.Core.Exceptions;

public class DbEditException : Exception
{
    public DbEditException()
    {

    }

    public DbEditException(string message) : base(message)
    {
    }

    public DbEditException(string message, Exception inner) : base(message, inner)
    {
    }
}
