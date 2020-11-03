package com.example.friendlyfoodfinder

import android.content.Intent
import android.os.Bundle
import com.google.android.material.snackbar.Snackbar
import androidx.appcompat.app.AppCompatActivity
import kotlinx.android.synthetic.main.activity_select_allergies.*
import kotlinx.android.synthetic.main.content_create_user.*
import kotlinx.android.synthetic.main.content_select_allergies.*

class SelectAllergies : AppCompatActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_select_allergies)
        setSupportActionBar(toolbar)
        fab.setOnClickListener { view ->
            Snackbar.make(view, "Replace with your own action", Snackbar.LENGTH_LONG)
                .setAction("Action", null).show()
            var builder = StringBuilder()
            if (checkBox3.isChecked) {
                builder.append(checkBox3.text.toString().subSequence(9, checkBox3.text.toString().length))
                builder.append(", ")
            }
            if (checkBox4.isChecked)
            {
                builder.append(checkBox4.text.toString().subSequence(10,checkBox4.text.toString().length))
                builder.append(", ")
            }
            if (checkBox5.isChecked)
            {
                builder.append(checkBox5.text.toString().subSequence(10,checkBox5.text.toString().length))
                builder.append(", ")
            }
            if (checkBox6.isChecked)
            {
                builder.append(checkBox6.text.toString().subSequence(10,checkBox6.text.toString().length))
                builder.append(", ")
            }
            if (checkBox7.isChecked)
            {
                builder.append(checkBox7.text.toString().subSequence(10,checkBox7.text.toString().length))
                builder.append(", ")
            }
            if (checkBox8.isChecked)
            {
                builder.append(checkBox8.text.toString().subSequence(10,checkBox8.text.toString().length))
                builder.append(", ")
            }
            val sharedPreferences = getApplicationContext().getSharedPreferences("Settings", 0);
            val editor = sharedPreferences.edit()
            editor.putString("alergiesList", builder.toString().subSequence(1,builder.toString().length-2).toString())
            editor.apply()
            // var main_intent = Intent(this, MainActivity::class.java)
            // startActivity(main_intent)
            finish()
        }
    }
}
