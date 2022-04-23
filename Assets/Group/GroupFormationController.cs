public class GroupFormationController
{
    GroupController group;
    public GroupFormationController (GroupController group)
    {
        this.group = group; 
    }
    public void BuildPyramidFormation()
    {
        group.SetFormation(new FPyramid(group));
    }
    public void BuildBlocFormation()
    {
        group.SetFormation(new FBloc(group.frontage, group));
    }
    public void BuildLineFormation()
    {
        group.SetFormation( new FLine(group));
    }
    public void BuildWedgeFormation()
    {
        group.SetFormation(new FWedge(group));
    }
    public void BuildColumnFormation()
    {
        group.SetFormation(new FColumn(group));
    }
}
