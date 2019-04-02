import java.util.ArrayDeque;
import java.util.Deque;
import java.util.LinkedList;

class MaxSlidingWindow{


    /**
     * @param arr array of values
     * @param windowSize: how many elements in list
     * @return
     */
    public static ArrayDeque<Integer> findMaxSlidingWindow(int[] arr, int windowSize) {

        ArrayDeque<Integer> result = new ArrayDeque<>(); // ArrayDeque for storing max values
        Deque<Integer> list = new LinkedList<Integer>(); // Linkedlist for storing indexes

        // how many times does the window slide.
        Window w = new Window();
        w.Start =0;
        w.End = 0;

        for(int i = 0; i< arr.length / windowSize; i++)
        {
            // get max array for element in window
            // slide array forward.
        }

        return result; // returning result
    }

    public static Window GetWindowIndexes(Integer i)
    {

        Window w = new Window();
        w.End = 0;
        w.Start = 0;
        return w;

    }
}

class Window
{
    int Start;
    int End;
}