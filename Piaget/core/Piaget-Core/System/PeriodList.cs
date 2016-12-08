﻿// A tester : si la liste des période a été vidée, est-ce qu'on appellera quand

using Piaget_Core.Lib;
using System;

namespace Piaget_Core.System {
    class PeriodNode : DoubleLinkedNode<PeriodNode> {
        public ulong period;
    }

    class PeriodList : DoubleLinkedListSorted<PeriodNode> {

        public PeriodList() : base(delegate (PeriodNode node) { return node.period; }) {}

        public void Add(ulong period) {
            this.Add(new PeriodNode { period = period });
        }
    }
}
