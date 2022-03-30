using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Config/ChanseSpawn", menuName = "Config/ChanseSpawn")]
public class ChanseCallculatorConfig : ScriptableObject
{
    public float appleChanseSpawn;
    public int maxKnifesAmountSpawn;
    public int minKnifesAmountSpawn;
    public int appleAmounSpaw;
    public int maxCircleSize;
    private HashSet<int> dontRepeat;

    public IEnumerable<int> GetNumbersPositionSpawn(int count)
    {
        //�� ����� �������� ������ ������, �� ������ ����� ������ ��������, ���� �������� �����������, ������ ������
        //�������� �� ����� ������ ��� �������������� ������ 4-6 ��������� ����� ����������� �� ��� �� ��������
        //����� ������ ������ ������
        dontRepeat = new HashSet<int>();
        while (count-- > 0)
        {
            int value = Random.Range(0, maxCircleSize);
            if (dontRepeat.Contains(value))
            {
                ++count;
                continue;
            }
            else
            {
                dontRepeat.Add(value);
                yield return value;
            }
        }
        
        dontRepeat.Clear();
    }

    public IEnumerable<string> GetObjectToSpawn(int count)
    {
        //�� ���� ������� ��� ������ ������ ���� ����, �� ����� ���������
        while (count-- > 0)
            yield return Random.value > .25 ? "knife" : "apple";
    }
}
