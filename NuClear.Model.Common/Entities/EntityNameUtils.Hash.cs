﻿using System;

namespace NuClear.Model.Common.Entities
{
    public static partial class EntityNameUtils
    {
        public static int EvaluateHashSimplified(this EntityType[] entities)
        {
            return EvaluateEntitiesHashSimplified(entities);
        }

        public static int EvaluateEntitiesHashSimplified(params EntityType[] entities)
        {
            const int Multipler = 0x1000193;
            int hash = 0x7b26bcc5;
            hash = (hash ^ entities.Length) * Multipler;
            hash = (hash ^ entities[0].AsInt()) * Multipler;
            hash = (hash ^ entities[entities.Length - 1].AsInt()) * Multipler;
            hash += hash << 13;
            hash ^= hash >> 7;
            hash += hash << 3;
            hash ^= hash >> 17;
            hash += hash << 5;

            return hash;
        }

        public static int EvaluateHash(this EntityType[] entities)
        {
            return EvaluateEntitiesHash(entities);
        }

        public static int EvaluateEntitiesHash(params EntityType[] entities)
        {
            // http://en.wikipedia.org/wiki/Jenkins_hash_function
            uint hash = 0;
            for (int index = 0; index < entities.Length; index++)
            {
                var entityName = entities[index];
                hash += (uint)entityName.AsInt();
                hash += hash << 10;
                hash ^= hash >> 6;
            }

            hash += hash << 3;
            hash ^= hash >> 11;
            hash += hash << 15;

            return (int)hash;
        }

        private static int AsInt(this EntityType entityType)
        {
            return (int)Convert.ChangeType(entityType, typeof(int));
        }
    }
}
