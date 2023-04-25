using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace pr14_3_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            int n = (int)numericUpDown1.Value;
            Queue task3 = new Queue();

            for (int i = 1; i <= n; i++) { task3.Enqueue(i); }

            while (task3.Count > 0)
            {
                int numbers = (int)task3.Dequeue();
                listBox1.Items.Add(numbers);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int n = (int)numericUpDown2.Value;
            Queue NewPeople = new Queue();
            Queue OldPeople = new Queue();
            listBox2.Items.Clear();
            listBox3.Items.Clear();

            FileInfo fileInfo = new FileInfo("info.txt");
            if (!fileInfo.Exists || fileInfo.Length == 0) 
            { 
                MessageBox.Show("Ошибка!", "Файл пустой или не найден."); 
                return;
            }
            StreamReader st = new StreamReader("info.txt");
            string line;
            while ((line = st.ReadLine()) != null)
            {
                string[] parts = line.Split(' ');
                string LastName = parts[0];
                string Name = parts[1];
                string MiddleName = parts[2];
                int age = int.Parse(parts[3]);
                int weight = int.Parse(parts[4]);

                if (age <= n)
                {
                    NewPeople.Enqueue($"{LastName} {Name} {MiddleName}, возраст: {age}, вес: {weight}"); 
                }
                else
                { 
                    OldPeople.Enqueue($"{LastName} {Name} {MiddleName}, возраст: {age}, вес: {weight}");
                }
            }
            
            foreach (string person in NewPeople) { listBox2.Items.Add(person); }
            foreach (string person in OldPeople) { listBox3.Items.Add(person); }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Queue<string> people = new Queue<string>();
            listBox4.Items.Clear();

            FileInfo fileInfo = new FileInfo("info.txt");
            if (!fileInfo.Exists || fileInfo.Length == 0) { MessageBox.Show("Ошибка!", "Файл пустой или не найден."); return; }

            StreamReader st = new StreamReader("info.txt");
            string line;
            while ((line = st.ReadLine()) != null)
            {
                people.Enqueue(line);
            }
            people = new Queue<string>(people.OrderBy(p => int.Parse(p.Split()[3])));
            Queue sortedPeople = new Queue();
            foreach (string person in people)
            {
                string[] parts = person.Split();
                sortedPeople.Enqueue($"{parts[0]} {parts[1]} {parts[2]}, возраст: {parts[3]}, вес: {parts[4]}");
            }
            foreach (string person in sortedPeople) { listBox4.Items.Add(person); }
        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
