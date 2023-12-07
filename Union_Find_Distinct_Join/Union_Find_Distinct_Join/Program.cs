// See https://aka.ms/new-console-template for more information

using Union_Find_Distinct_Join;

DistinctSet distinctSet = new DistinctSet(7);
distinctSet.UnionBySize(1,2);
distinctSet.UnionBySize(2,3);
distinctSet.UnionBySize(4,5);
distinctSet.UnionBySize(6,7);
distinctSet.UnionBySize(5,6);
distinctSet.UnionBySize(3,7);

int parentU = distinctSet.FindParent(1);
int parentV = distinctSet.FindParent(7);

Console.WriteLine($"{parentU == parentV} are part of same component" );