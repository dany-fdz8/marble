using System;
using System.Text;
using marble.Model;

namespace marble.MarbleHandler
{
    public class MarbleHandler
    {

        public List<Marble> validateMarbleList(List<Marble> marbles)
        {
            List<Marble> finalMarbleList = new List<Marble>();

            foreach (var m in marbles)
            {
                if (isNamePalindrome(m.name) && isValidWeight(m.weight))
                {
                    finalMarbleList.Add(m);
                }

            }

            finalMarbleList = sortMarbleList(finalMarbleList, 0, finalMarbleList.Count - 1);

            return finalMarbleList;
        }

        public bool isNamePalindrome(string name)
        {
            bool result = false;
            string reversedName = string.Empty;
            string modifiedName = removeSpecialCharacters(name);

            char[] c = modifiedName.ToCharArray();
            Array.Reverse(c);
            reversedName = new string(c);
            result = modifiedName.Equals(reversedName, StringComparison.OrdinalIgnoreCase);

            return result;
        }

        public string removeSpecialCharacters(string name)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in name)
            {
                if ((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z'))
                {
                    sb.Append(c);
                }
            }

            return sb.ToString();
        }

        public bool isValidWeight(double weight)
        {
            bool result = false;

            if (weight >= .5)
            {
                result = true;
            }

            return result;
        }

        public List<Marble> sortMarbleList(List<Marble> marbles, int left, int right)
        {
            if (left < right)
            {
                int middle = left + (right - left) / 2;

                sortMarbleList(marbles, left, middle);
                sortMarbleList(marbles, middle + 1, right);

                merge(marbles, left, middle, right);
            }

            return marbles;
        }

        public List<Marble> merge(List<Marble> marbles, int left, int middle, int right)
        {
            Dictionary<string, int> colorsValues = new Dictionary<string, int>()
            {
                { "red", 1 },
                { "orange", 2 },
                { "yellow", 3 },
                { "green", 4 },
                { "blue", 5 },
                { "indigo", 6 },
                { "violet", 7 }
            };

            int leftArrayLength = middle - left + 1;
            int rightArrayLength = right - middle;
            List<Marble> leftTempArray = new List<Marble>();
            List<Marble> rightTempArray = new List<Marble>();

            int i, j;
            for (i = 0; i < leftArrayLength; ++i)
            {
                leftTempArray.Add(marbles[left + i]);
            }
            for (j = 0; j < rightArrayLength; ++j)
            {
                rightTempArray.Add(marbles[middle + 1 + j]);
            }

            i = 0;
            j = 0;
            int k = left;

            while (i < leftArrayLength && j < rightArrayLength)
            {
                if (colorsValues[leftTempArray[i].color] <= colorsValues[rightTempArray[j].color])
                {
                    marbles[k++] = leftTempArray[i++];
                }
                else
                {
                    marbles[k++] = rightTempArray[j++];
                }
            }

            while (i < leftArrayLength)
            {
                marbles[k++] = leftTempArray[i++];
            }

            while (j < rightArrayLength)
            {
                marbles[k++] = rightTempArray[j++];
            }

            return marbles;
        }
    }
}

