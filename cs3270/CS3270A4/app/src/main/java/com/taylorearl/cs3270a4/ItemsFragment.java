package com.taylorearl.cs3270a4;


import android.content.Context;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.text.Editable;
import android.text.TextWatcher;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.EditText;


/**
 * A simple {@link Fragment} subclass.
 */
public class ItemsFragment extends Fragment {


    public ItemsFragment() {
        // Required empty public constructor
    }

    EditText edit1, edit2, edit3, edit4;
    View rootView;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        rootView = (View) inflater.inflate(R.layout.fragment_items, container, false);

        edit1 = (EditText) rootView.findViewById(R.id.editText);
        edit2 = (EditText) rootView.findViewById(R.id.editText2);
        edit3 = (EditText) rootView.findViewById(R.id.editText3);
        edit4 = (EditText) rootView.findViewById(R.id.editText4);

        edit1.addTextChangedListener(amountChanged);
        edit2.addTextChangedListener(amountChanged);
        edit3.addTextChangedListener(amountChanged);
        edit4.addTextChangedListener(amountChanged);

        return rootView;
    }

    private void calcTotal(){
        double tAmount = 0.0;
        tAmount += Double.parseDouble("0" + edit1.getText().toString());
        tAmount += Double.parseDouble("0" + edit2.getText().toString());
        tAmount += Double.parseDouble("0" + edit3.getText().toString());
        tAmount += Double.parseDouble("0" + edit4.getText().toString());
        MainActivity ma = (MainActivity) getActivity();
        ma.setItemTotals(tAmount);
    }

    public TextWatcher amountChanged = new TextWatcher() {
        @Override
        public void beforeTextChanged(CharSequence charSequence, int i, int i1, int i2) {

        }

        @Override
        public void onTextChanged(CharSequence charSequence, int i, int i1, int i2) {

        }

        @Override
        public void afterTextChanged(Editable editable) {
            calcTotal();
        }
    };

    public void setDisplay(double one, double two, double three, double four){
        edit1.setText(Double.toString(one));
        edit2.setText(Double.toString(two));
        edit3.setText(Double.toString(three));
        edit4.setText(Double.toString(four));
    }

    @Override
    public void onPause() {
        super.onPause();
        MainActivity ma = (MainActivity) getActivity();
        Double one = Double.parseDouble("0" + edit1.getText().toString());
        Double two = Double.parseDouble("0" + edit2.getText().toString());
        Double three = Double.parseDouble("0" + edit3.getText().toString());
        Double four = Double.parseDouble("0" + edit4.getText().toString());
        ma.saveItems(one, two, three, four);
    }
}
