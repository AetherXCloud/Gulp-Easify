using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gulp_Easify
{
    public partial class GulpFile : Form
    {
        public GulpFile()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                        m.Result = (IntPtr)0x2;
                    return;
            }

            base.WndProc(ref m);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string SassImport = "";
            string Sass = "";
            string JadeImport = "";
            string Jade = "";
            string MinImport = "";
            string Min = "";
            string watch = "gulp.task('watch', function() {";
            string curFile = @"gulpfile.js";
            if (File.Exists(curFile))
            {
                FileInfo fi = new FileInfo(curFile);
                using (TextWriter sw = new StreamWriter(fi.Open(FileMode.Truncate)))
                {
                    sw.Write("");
                    if (checkBox1.Checked)
                    {
                        SassImport = "var sass = require('gulp-sass');";
                        Sass = @"gulp.task('sass', function () {gulp.src('" + textBox1.Text + "/**/*.sass').pipe(sass().on('error', sass.logError)).pipe(gulp.dest('" + textBox2.Text + "/css'));});";
                        watch = watch + "gulp.watch('" + textBox1.Text + "/**/*.sass', ['sass']);";
                    }
                    if (checkBox1.Checked)
                    {
                        MinImport = "var sass = require('gulp-uglify');";
                        Min = @"gulp.task('min', function() {return gulp.src('" + textBox1.Text + "/**/*.js').pipe(uglify()).pipe(gulp.dest('" + textBox2.Text + "/js'));});";
                        watch = watch + "gulp.watch('" + textBox1.Text + "/**/*.js', ['min']);";
                    }
                    if (checkBox2.Checked)
                    {

                        JadeImport = "var jade = require('gulp-jade');";
                        Jade = @"gulp.task('jade', function() {return gulp.src('" + textBox1.Text + "/**/*.jade').pipe(jade()).pipe(gulp.dest('" + textBox2.Text + "'));});";
                        watch = watch + "gulp.watch('" + textBox1.Text + "/**/*.jade', ['jade']);";
                    }
                    watch = watch + "});";
                    sw.WriteLine("var gulp = require('gulp');");
                    sw.WriteLine(JadeImport);
                    sw.WriteLine(SassImport);
                    sw.WriteLine(MinImport);
                    sw.WriteLine(watch);
                    sw.WriteLine(Sass);
                    sw.WriteLine(Jade);
                    sw.WriteLine(Min);
                    sw.WriteLine(@"gulp.task('default', function() {console.log('Welcome To Gulp Easify');}); ");
                }
            }
            else {
                FileInfo fi = new FileInfo(curFile);
                using (TextWriter sw = new StreamWriter(File.Create(curFile)))
                {
                    sw.Write("");
                    if (checkBox1.Checked)
                    {
                        SassImport = "var sass = require('gulp-sass');";
                        Sass = @"gulp.task('sass', function () {gulp.src('" + textBox1.Text + "/**/*.sass').pipe(sass().on('error', sass.logError)).pipe(gulp.dest('" + textBox2.Text + "/css'));});";
                        watch = watch + "gulp.watch('" + textBox1.Text + "/**/*.sass', ['sass']);";
                    }
                    if (checkBox1.Checked)
                    {
                        MinImport = "var uglify = require('gulp-uglify');";
                        Min = @"gulp.task('min', function() {return gulp.src('" + textBox1.Text + "/**/*.js').pipe(uglify()).pipe(gulp.dest('" + textBox2.Text + "/js'));});";
                        watch = watch + "gulp.watch('" + textBox1.Text + "/**/*.js', ['min']);";
                    }
                    if (checkBox2.Checked)
                    {

                        JadeImport = "var jade = require('gulp-jade');";
                        Jade = @"gulp.task('jade', function() {return gulp.src('" + textBox1.Text + "/**/*.jade').pipe(jade()).pipe(gulp.dest('" + textBox2.Text + "'));});";
                        watch = watch + "gulp.watch('" + textBox1.Text + "/**/*.jade', ['jade']);";
                    }
                    watch = watch + "});";
                    sw.WriteLine("var gulp = require('gulp');");
                    sw.WriteLine(JadeImport);
                    sw.WriteLine(SassImport);
                    sw.WriteLine(MinImport);
                    sw.WriteLine(watch);
                    sw.WriteLine(Sass);
                    sw.WriteLine(Jade);
                    sw.WriteLine(Min);
                    sw.WriteLine(@"gulp.task('default', function() {console.log('Welcome To Gulp Easify');}); ");
                }
            }
        }
    }
}
