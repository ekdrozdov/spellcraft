using System.Collections.Generic;

public class CategorizedSkills
{
  public List<ScalarSkill> ScalarSkills { get; }
  public List<MassSkill> MassSkills { get; }
  public List<VectorSkill> VectorSkills { get; }

  public CategorizedSkills()
  {
    ScalarSkills = new List<ScalarSkill>();
    MassSkills = new List<MassSkill>();
    VectorSkills = new List<VectorSkill>();
  }
}
