using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Specialty.Domain.Repository;
using Specialty.Domain.Models;

namespace Specialty.Web.Models
{
    public static class TreeHandler
    {
        private static SpecialtyRepository repository;

        static TreeHandler()
        {
            repository = new SpecialtyRepository();
        }

        public static IEnumerable<EnrolmentUnit> GetDirectChildren(int nodeId)
        {
            return repository.EnrolmentUnits.Where(u => u.ParentId == nodeId);
        }

        public static IEnumerable<EnrolmentUnit> GetGrandestChildren(int nodeId)
        {
            EnrolmentUnit node = FindNode(nodeId);
            List<EnrolmentUnit> grandestChildren = new List<EnrolmentUnit>();
            GrandestChildrenSearchRecursion(node, grandestChildren);
            return grandestChildren;
        }

        private static void GrandestChildrenSearchRecursion(EnrolmentUnit node, List<EnrolmentUnit> storage)
        {
            var children = GetDirectChildren(node.Id);
            if (children.Count() == 0)
            {
                storage.Add(node);
                return;
            }
            foreach (var child in children)
            {
                GrandestChildrenSearchRecursion(child, storage);
            }
        }

        private static EnrolmentUnit FindNode(int nodeId)
        {
            return repository.EnrolmentUnits.Where(u => u.Id == nodeId).SingleOrDefault();
        }
    }
}