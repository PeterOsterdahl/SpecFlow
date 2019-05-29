﻿using System;
using TechTalk.SpecFlow.CommonModels;

namespace TechTalk.SpecFlow.EnvironmentAccess
{
    public class EnvironmentWrapper : IEnvironmentWrapper
    {
        public bool IsEnvironmentVariableSet(string name)
        {
            return Environment.GetEnvironmentVariables().Contains(name);
        }

        public IResult<string> GetEnvironmentVariable(string name)
        {
            if (IsEnvironmentVariableSet(name))
            {
                return Result<string>.Success(Environment.GetEnvironmentVariable(name));
            }

            return Result<string>.Failure($"Environment variable {name} not set");
        }

        public void SetEnvironmentVariable(string name, string value)
        {
            Environment.SetEnvironmentVariable(name, value, EnvironmentVariableTarget.Process);
        }
    }
}