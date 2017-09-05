package com.taylorearl.assignment2;

import android.app.Fragment;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

public class MainActivity extends AppCompatActivity {

    Button btnLoad2;
    Button btnLoad4;
    Button btnLoad3;
    Button btnSwitch34;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        getSupportFragmentManager().beginTransaction()
                .replace(R.id.fragmentContainer1, new FragmentA(), "FA")
                .addToBackStack(null)
                .commit();

        btnLoad2 = (Button)findViewById(R.id.btnloadF2);
        btnLoad2.setOnClickListener(new View.OnClickListener(){
            public void onClick(View view){
                getSupportFragmentManager().beginTransaction()
                        .replace(R.id.fragmentContainer2, new FragmentB(), "FB")
                        .addToBackStack(null)
                        .commit();
            }
        });

        btnLoad3 = (Button)findViewById(R.id.btnloadF3);
        btnLoad3.setOnClickListener(new View.OnClickListener(){
            public void onClick(View view){
                getSupportFragmentManager().beginTransaction()
                        .replace(R.id.fragmentContainer3, new FragmentC(), "FC")
                        .addToBackStack(null)
                        .commit();
            }
        });

        btnLoad4 = (Button)findViewById(R.id.btnloadF4);
        btnLoad4.setOnClickListener(new View.OnClickListener(){
            public void onClick(View view){
                getSupportFragmentManager().beginTransaction()
                        .replace(R.id.fragmentContainer4, new FragmentD(), "FD")
                        .addToBackStack(null)
                        .commit();
            }
        });

        btnSwitch34 = (Button)findViewById(R.id.btnswitch34);
        btnSwitch34.setOnClickListener(new View.OnClickListener(){
            public void onClick(View view){
                getSupportFragmentManager().beginTransaction()
                        .replace(R.id.fragmentContainer4, new FragmentC(), "FC")
                        .addToBackStack(null)
                        .commit();
                getSupportFragmentManager().beginTransaction()
                        .replace(R.id.fragmentContainer3, new FragmentD(), "FD")
                        .addToBackStack(null)
                        .commit();
            }
        });
    }

}
