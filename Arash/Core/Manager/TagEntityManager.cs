﻿using System;
using System.Collections.Generic;
using Arash.Core.Model;
using Paradiso.Infrastructure.Data;
using Arash.Infrastructure.Data;

namespace Arash.Core.Manager
{
    public class TagEntityManager : ITagEntityManager
    {
        private IRepository<TagEntity> _repository;

        public TagEntityManager(IRepository<TagEntity> repository)
        {
            _repository = repository;
        }

        public TagEntity MakeInstance()
        {
            return _repository.NewEntityInstance();
        }

        public void Add(TagEntity entity)
        {
            _repository.Add(entity);
            _repository.Save();
        }

        public void Edit(TagEntity entity)
        {
            _repository.Save();
        }

        public void Remove(TagEntity entity)
        {
            _repository.Remove(entity);
            _repository.Save();
        }

        public int GetCount(Func<TagEntity, bool> predicate = null)
        {
            return predicate == null
                ? _repository.GetCount(p => true)
                : _repository.GetCount(predicate);
        }

        public TagEntity Get(Func<TagEntity, bool> predicate = null)
        {
            return predicate == null
                ? _repository.Get(p => true)
                : _repository.Get(predicate);
        }

        public IEnumerable<TagEntity> GetAll(Func<TagEntity, bool> predicate = null, int start = 0, int count = 6)
        {
            return predicate == null
                 ? _repository.GetAll(p => true)
                 : start == 0
                     ? _repository.GetAll(predicate)
                     : _repository.GetAll(predicate, start, count);
        }
    }
}
