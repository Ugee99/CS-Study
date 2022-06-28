using MySql.Data.MySqlClient;

namespace Project2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<User> users = DBAccess.Instance.SelectUsers();

            // �����ͱ׸���� ������ ����
            dataGridView1.DataSource = users;
        }

        //�� Ŭ���ϸ� Text�ڽ��� ����
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[selectedRow];

            string name = row.Cells[0].Value.ToString();
            string uid  = row.Cells[1].Value.ToString();
            string hp   = row.Cells[2].Value.ToString();
            int    age  = (int)row.Cells[3].Value;

            txtUid.Text  = uid;
            txtName.Text = name;
            txtHp.Text   = hp;
            nAge.Value   = age;
        }

        //��ȸ
        private void btnSelect_Click(object sender, EventArgs e)
        {
            List<User> users = DBAccess.Instance.SelectUsers();

            // �����ͱ׸���� ������ ����
            dataGridView1.DataSource = users;
        }

        //�߰�
        private void btnInsert_Click(object sender, EventArgs e)
        {
            string  uid  = txtUid.Text.ToString();
            string  name = txtName.Text.ToString();
            string  hp   = txtHp.Text.ToString();
            decimal age  = nAge.Value;

            DBAccess.Instance.InsertUser(uid, name, hp, age);
            Reset();
        }

        //����
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string  uid  = txtUid.Text.ToString();
            string  name = txtName.Text.ToString();
            string  hp   = txtHp.Text.ToString();
            decimal age  = nAge.Value;

            DBAccess.Instance.UpdateUser(uid, name, hp, age);
        }

        //����
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string uid = txtUid.Text.ToString();
            DBAccess.Instance.DeleteUser(uid);
        }

        //����
        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        public void Reset()
        {
            txtUid.Text  = "";
            txtName.Text = "";
            txtHp.Text   = "";
            nAge.Text    = "0";
        }
    }
}