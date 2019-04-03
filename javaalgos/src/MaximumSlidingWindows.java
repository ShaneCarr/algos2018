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
        Integer startIndex = 0;

        boolean windowSlides = true;
        while(!GetWindowIndexes(
                w,
                windowSize,
                startIndex,
                arr.length - 1,
                result,
                arr))
        {
            startIndex++;
        }

        return result; // returning result
    }

    /**
     *
     * @param w the current window
     * @param maxArrayBound bounds
     * @return should continue
     */
    public static boolean GetWindowIndexes(
            Window w,
            Integer windowSize,
            Integer startIndex,
            int maxArrayBound,
            ArrayDeque<Integer> result,
            int[] a)
    {
        boolean doneOrNot = false;
        Integer endIndexBound = 0;
        Integer additionalSteps = windowSize - 1;
        if(startIndex + additionalSteps >= maxArrayBound)
        {
            doneOrNot = true;
            endIndexBound = maxArrayBound;
        }
        else
        {
            endIndexBound = startIndex + additionalSteps; // take one off the window size because we count current.
        }

        // 2 (windows bound comes from (3-1)
        // 0, 2 -> 0,1,2
        // 1, 2 -> 1,2,3
        w.End = endIndexBound;

        // 0
        // 1
        w.Start = startIndex;

        Integer max = Integer.MIN_VALUE;

        for(Integer i = w.Start; i <= w.End; i++) {
            if(max < a[i])
            {
                max = a[i];
            }
        }

        result.add(max);
        return doneOrNot;
    }
}

class Window
{
    int Start;
    int End;
}