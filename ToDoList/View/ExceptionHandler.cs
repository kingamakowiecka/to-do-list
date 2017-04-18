﻿using System;
using System.Data.Entity.Validation;
using System.Linq;

namespace ToDoList.View
{
    public class ExceptionHandler
    {
        public String HandleException(Exception exception)
        {
            String errorMessage;

            if (exception is DbEntityValidationException)
            {
                errorMessage = ((DbEntityValidationException)exception).EntityValidationErrors
                    .SelectMany(x => x.ValidationErrors)
                    .Select(x => x.ErrorMessage).First();
            }
            else if (exception is ArgumentNullException)
            {
                errorMessage = "Item can't be empty";
            }
            else
            {
                errorMessage = exception.GetBaseException().Message;
            }

            return errorMessage;
        }
    }
}