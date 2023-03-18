﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNN.Core.Business.Extensions;

public static class ErrorMsg
{
    public static string ToAlReadyExistMsg(this string fieldName)
    {
        return $"This {fieldName} already exist !";
    }
    public static string ToNotExistMsg(this string fieldName)
    {
        return $"This {fieldName} is not found !";
    }
    public static string ToInvalidMsg(this string fieldName)
    {
        return $"This {fieldName} is invalid !";
    }

    public static string ToRequiredMsg(this string fieldName)
    {
        return $"The {fieldName} field is required.";
    }

    public static string ToGreaterThanMsg(this string fieldName, string otherField)
    {
        return $"The {fieldName} is greater than the {otherField}";
    }

    public static string ToTwoNotEmptyMsg(this string fieldName, string otherField)
    {
        return $"{fieldName} and {otherField} fields cannot both be empty";
    }
}