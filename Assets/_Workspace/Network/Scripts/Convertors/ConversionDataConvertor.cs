public static class ConversionDataConvertor
{
    public static string ToJson(string value)
    {
        string newValue = "{";

        for (int i = 0; i < value.Length; i++)
        {
            if (value[i] == '[')
            {
                newValue += "\"";
            }
            else if (value[i] == ',')
            {
                newValue += "\":\"";
            }
            else if (value[i] == ']')
            {
                if (i == value.Length - 1) { }
                else
                {
                    newValue += "\",";
                }
            }
            else
            {
                newValue += value[i];
            }
        }

        newValue += "\"}";

        return newValue;
    }
}
