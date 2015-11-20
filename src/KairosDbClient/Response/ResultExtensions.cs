﻿using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace KairosDbClient.Response
{
    public static class ResultExtensions
    {
        public static IEnumerable<TypedDatapoint<T>> GetTypedDatapoints<T>(this Result result)
        {
            return result.Values
                .Select(value =>
                {
                    var serialized = JsonConvert.SerializeObject(value[1]);
                    return new TypedDatapoint<T>()
                    {
                        TimeStamp = (long) value[0],
                        Value = JsonConvert.DeserializeObject<T>(serialized)
                    };
                });
        }
    }
}