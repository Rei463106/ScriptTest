using System.Collections.Generic;

/// <summary>
/// •¶š—ñ‚Ì•ª‰ğ‚ğs‚¤
/// </summary>
public class ComfirmationProcess
{
    private Queue<char> _queue = new Queue<char>();//ó‚¯æ‚Á‚½•¶š—ñ‚ğchar‰»
    public Queue<char> Queue => _queue;

    public ComfirmationProcess(string st)
    {
        var c = st.ToCharArray();
        foreach (char ch in c)
        {
            _queue.Enqueue(ch);
        }
    }
}
