import org.junit.jupiter.api.Test;

import java.util.ArrayDeque;

import static org.junit.jupiter.api.Assertions.*;

class MaxSlidingWindowTest {

    @Test
    void findMaxSlidingWindow() {
        int[] array = {5,6,3};

        ArrayDeque<Integer> maximum = MaxSlidingWindow.findMaxSlidingWindow(array, 3);
        Integer item = maximum.pop();
        assertEquals(item, 6);
    }

    @Test
    void findMaxSlidingWindowTwo() {
        int[] array = {5,6,3,9};

        ArrayDeque<Integer> maximum = MaxSlidingWindow.findMaxSlidingWindow(array, 3);
        Integer item = maximum.pop();
        assertEquals(item, 6);

        item = maximum.pop();
        assertEquals(item, 9);
    }

    @Test
    void findMaxSlidingWindowThree() {
        int[] array = {1, 2, 3, 4, 3, 2, 1, 2, 5};

        ArrayDeque<Integer> maximum = MaxSlidingWindow.findMaxSlidingWindow(array, 4);
        Integer item = maximum.pop();
        assertEquals(item, 4);

        item = maximum.pop();
        assertEquals(item, 4);


        item = maximum.pop();
        assertEquals(item, 4);

        item = maximum.pop();
        assertEquals(item, 4);

        item = maximum.pop();
        assertEquals(item, 3);

        item = maximum.pop();
        assertEquals( 5, item);
    }
}


