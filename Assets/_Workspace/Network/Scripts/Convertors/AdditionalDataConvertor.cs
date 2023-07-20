public static class AdditionalDataConvertor
{
    public static string ToJson(string value)
    {
        string newValue = "{";

        bool isString = false;

        for (int i = 1; i < value.Length - 1; i++)
        {
            if (value[i] == '{')
            {
                newValue += '"';
                newValue += value[i];
            }
            else if (value[i] == '}')
            {
                newValue += value[i];
                newValue += '"';

                isString = true;
            }
            else if (value[i] == '"')
            {
                if (i > 5 && isString == false)
                {
                    newValue += '\\';

                    newValue += value[i];
                }
                else
                {
                    newValue += value[i];
                }
            }
            else
            {
                newValue += value[i];
            }
        }

        newValue += '}';

        return newValue;
    }
}
