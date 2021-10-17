using System.Collections.Generic;

public class CategorizedSkills
{
  public List<ScalarSkill> ScalarSkills { get; }
  public List<IMassSkill> MassSkills { get; }

  public CategorizedSkills()
  {
    ScalarSkills = new List<ScalarSkill>();
    MassSkills = new List<IMassSkill>();
  }
}
