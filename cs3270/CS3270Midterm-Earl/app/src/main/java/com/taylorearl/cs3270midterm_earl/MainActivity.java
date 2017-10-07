package com.taylorearl.cs3270midterm_earl;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        Log.d("testing", "in onCreate Main");
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        getSupportFragmentManager().beginTransaction()
                .replace(R.id.top, new ActionFragment(), "TOP")
                .commit();
        getSupportFragmentManager().beginTransaction()
                .replace(R.id.bottom, new ResultsFragment(), "BOT")
                .commit();
    }


    public void calculate(int lbs, int in, int age, boolean isFemale){
        Log.d("testing", "in calculate main");
        double bmi = 0;
        double bfp = 0;
        int sex = 0;
        float two = 2;
        if(isFemale == true){
            sex = 1;
        }
        ResultsFragment results = (ResultsFragment) getSupportFragmentManager().findFragmentByTag("BOT");
        bmi = lbs / Math.pow((double)in, 2.0) * 703;
        bfp = (1.20 * bmi) + (.23 * age) - (10.8 * sex) - 5.4;

        results.setBMI((float)bmi);
        results.setBFP((float)bfp);
    }
}
