using System;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Math;

namespace Image_Filter
{
    public partial class Form1 : Form
    {

        string base_file_path = null;
        Bitmap GreyScale = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void AddImage_Click(object sender, EventArgs e)
        {
            FileDialog.ShowDialog();

            base_file_path = FileDialog.FileName;
            base_image.SizeMode = PictureBoxSizeMode.Zoom;
            base_image.Image = System.Drawing.Image.FromFile(base_file_path);

        }

        private Bitmap ColorFilter(Bitmap _currentBitmap, string color)
        {
            int width = _currentBitmap.Width;
            int height = _currentBitmap.Height;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color Pixel = _currentBitmap.GetPixel(x, y);

                    if (color.CompareTo("red") == 0)
                        _currentBitmap.SetPixel(x, y, Color.FromArgb(Pixel.A, Pixel.R, 0, 0));
                    else if (color.CompareTo("blue") == 0)
                        _currentBitmap.SetPixel(x, y, Color.FromArgb(Pixel.A, 0, 0, Pixel.B));
                    else
                        _currentBitmap.SetPixel(x, y, Color.FromArgb(Pixel.A, 0, Pixel.G, 0));
                }
            }

            return _currentBitmap;
        }

        private void Blue_Filter_Click(object sender, EventArgs e)
        {
            System.Drawing.Image blue_image = System.Drawing.Image.FromFile(base_file_path);
            Bitmap blue_map = GetArgbCopy(blue_image);
            blue_map = ColorFilter(blue_map, "blue");
            filtered_image.Image = blue_map;
            filter_name.Text = "Blue Filter";
        }

        private void Red_Filter_Click(object sender, EventArgs e)
        {
            System.Drawing.Image blue_image = System.Drawing.Image.FromFile(base_file_path);
            Bitmap blue_map = GetArgbCopy(blue_image);
            blue_map = ColorFilter(blue_map, "red");
            filtered_image.Image = blue_map;
            filter_name.Text = "Red Filter";
        }

        private void Green_Filter_Click(object sender, EventArgs e)
        {
            System.Drawing.Image blue_image = System.Drawing.Image.FromFile(base_file_path);
            Bitmap blue_map = GetArgbCopy(blue_image);
            blue_map = ColorFilter(blue_map, "green");
            filtered_image.Image = blue_map;
            filter_name.Text = "Green Filter";
        }

        private static Bitmap GetArgbCopy(System.Drawing.Image sourceImage)
        {
            Bitmap bmpNew = new Bitmap(sourceImage.Width, sourceImage.Height, PixelFormat.Format32bppArgb);
            
            using (Graphics graphics = Graphics.FromImage(bmpNew))
            {
                graphics.DrawImage(sourceImage, new Rectangle(0, 0, bmpNew.Width, bmpNew.Height), new Rectangle(0, 0, bmpNew.Width, bmpNew.Height), GraphicsUnit.Pixel);
                graphics.Flush();
            }

            return bmpNew;
        }

        private void GreyScale_Button_Click(object sender, EventArgs e)
        {
            System.Drawing.Image base_image = System.Drawing.Image.FromFile(base_file_path);

            GreyScale = GetArgbCopy(base_image);

            GreyScale = GetGrayScale(GreyScale);

            filtered_image.Image = GreyScale;
            filter_name.Text = "Greyscale Image";
        }

        private Bitmap GetGrayScale(Bitmap original)
        {
            for (int i = 0; i < original.Width; i++)
            {
                for (int x = 0; x < original.Height; x++)
                {
                    Color oc = original.GetPixel(i, x);
                    int grayScale = (int)((oc.R * 0.3) + (oc.G * 0.59) + (oc.B * 0.11));
                    Color nc = Color.FromArgb(oc.A, grayScale, grayScale, grayScale);
                    original.SetPixel(i, x, nc);
                }
            }

            return original;
        }

        private void DFT_Button_Click(object sender, EventArgs e)
        {
            try
            {
                System.Drawing.Image original = System.Drawing.Image.FromFile(base_file_path);
                Bitmap original_map = GetArgbCopy(original);
                Grayscale filter = new Grayscale(0.3, 0.59, 0.11);
                Bitmap Grey_scale = filter.Apply(original_map);
                filtered_image.Image = Grey_scale;

                ComplexImage GreyImage = ComplexImage.FromBitmap(Grey_scale);

                GreyImage.ForwardFourierTransform();

                Complex[,] Final_Image = GreyImage.Data;

                Double[,] PhaseData = GetPhase(Final_Image);

                Bitmap Phase_Image = Matrix2ImageLog(PhaseData);
                filtered_image.Image = Phase_Image;
                filter_name.Text = "Phase Image";

                Double[,] MagData = GetMagnitude(Final_Image);

                Bitmap Mag_Image = Matrix2ImageLog(MagData);

                Mag_Image = ConvertToFormat(Mag_Image, PixelFormat.Format24bppRgb);

                Mag_Image = LogaritmicScaling(Mag_Image);

                Fourier_Image.Image = Mag_Image;

                trans_name.Text = "Amplitude Image";
            }
            catch(Exception s)
            {
                MessageBox.Show(s.ToString());
            }
        }

        private Double[,] GetPhase(Complex [,] data)
        {

            Double[,] PhaseData = new Double[data.GetLength(0), data.GetLength(1)];

            for (int i=0;i< data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    PhaseData[i, j] = data[i, j].Phase;
                }
            }

            return PhaseData;
        }

        private Double[,] GetMagnitude(Complex[,] data)
        {
            Double[,] MagData = new Double[data.GetLength(0),data.GetLength(1)];

            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    MagData[i, j] = data[i, j].Magnitude;
                }
            }

            return MagData;
        }

        public Bitmap Matrix2ImageLog(Double[,] Matrix)
        {
            Bitmap img = new Bitmap(Matrix.GetLength(0), Matrix.GetLength(1));

            Double max = Matrix.Cast<Double>().Max();

            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {

                    Double a = 255 / Math.Log10(1 + max);

                    int value = (int)(a * Math.Log10(1 + Matrix[i, j]));
                    if (value > 255 || value < 0)
                        value = 125;

                    Color p = Color.FromArgb(255, value, value, value);

                    img.SetPixel(i, j, p);
                }
            }
            
            return img;
        }

        private void IDFT_Button_Click(object sender, EventArgs e)
        {
            System.Drawing.Image original = System.Drawing.Image.FromFile(base_file_path);
            Bitmap original_map = GetArgbCopy(original);
            Grayscale filter = new Grayscale(0.3, 0.59, 0.11);
            Bitmap Grey_scale = filter.Apply(original_map);

            filtered_image.Image = Grey_scale;

            ComplexImage GreyImage = ComplexImage.FromBitmap(Grey_scale);

            GreyImage.BackwardFourierTransform();

            Bitmap image = GreyImage.ToBitmap();

            Fourier_Image.Image = image;

            filter_name.Text = "Greyscale Image";
            trans_name.Text = "IDFT Filter";
        }

        public Bitmap LogaritmicScaling(Bitmap OriginalImage)
        {
            Bitmap img = new Bitmap(OriginalImage.Width, OriginalImage.Height);

            int[,] r = RMatrix(OriginalImage);
            int[,] g = GMatrix(OriginalImage);
            int[,] b = BMatrix(OriginalImage);

            Double maxR = Convert.ToDouble(r.Cast<int>().Max());
            Double maxG = Convert.ToDouble(g.Cast<int>().Max());
            Double maxB = Convert.ToDouble(b.Cast<int>().Max());

            for (int i = 0; i < OriginalImage.Width; i++)
            {
                for (int j = 0; j < OriginalImage.Height; j++)
                {

                    Double aR = 255 / Math.Log10(1 + maxR);
                    int valueR = (int)(aR * Math.Log10(1 + OriginalImage.GetPixel(i, j).R));

                    Double aG = 255 / Math.Log10(1 + maxG);
                    int valueG = (int)(aG * Math.Log10(1 + OriginalImage.GetPixel(i, j).G));

                    Double aB = 255 / Math.Log10(1 + maxB);
                    int valueB = (int)(aB * Math.Log10(1 + OriginalImage.GetPixel(i, j).B));

                    Color p = Color.FromArgb(255, valueR, valueG, valueB);

                    img.SetPixel(i, j, p);
                }
            }
            
            return img;
        }

        public int[,,] RGBMatrix(Bitmap OriginalImage)
        {
            int M = OriginalImage.Width;
            int N = OriginalImage.Height;

            int[,,] RGB = new int[3, M, N];

            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {

                    Color p = OriginalImage.GetPixel(i, j);

                    RGB[0, i, j] = p.R;
                    RGB[1, i, j] = p.G;
                    RGB[2, i, j] = p.B;

                }
            }

            return RGB;
        }

        public int[,] RMatrix(Bitmap OriginalImage)
        {
            int[,,] rgb = this.RGBMatrix(OriginalImage);

            int[,] p = new int[OriginalImage.Width, OriginalImage.Height];

            for (int i = 0; i < OriginalImage.Width; i++)
            {
                for (int j = 0; j < OriginalImage.Height; j++)
                {
                    p[i, j] = rgb[0, i, j];
                }
            }

            return p;
        }

        public int[,] GMatrix(Bitmap OriginalImage)
        {
            int[,,] rgb = this.RGBMatrix(OriginalImage);

            int[,] p = new int[OriginalImage.Width, OriginalImage.Height];

            for (int i = 0; i < OriginalImage.Width; i++)
            {
                for (int j = 0; j < OriginalImage.Height; j++)
                {
                    p[i, j] = rgb[1, i, j];
                }
            }

            return p;
        }

        public int[,] BMatrix(Bitmap OriginalImage)
        {
            int[,,] rgb = this.RGBMatrix(OriginalImage);

            int[,] p = new int[OriginalImage.Width, OriginalImage.Height];

            for (int i = 0; i < OriginalImage.Width; i++)
            {
                for (int j = 0; j < OriginalImage.Height; j++)
                {
                    p[i, j] = rgb[2, i, j];
                }
            }

            return p;
        }

        private void HighPass_Button_Click(object sender, EventArgs e)
        {
            System.Drawing.Image original = System.Drawing.Image.FromFile(base_file_path);
            Bitmap original_map = GetArgbCopy(original);
            Grayscale filter = new Grayscale(0.3, 0.59, 0.11);
            Bitmap Grey_scale = filter.Apply(original_map);

            filtered_image.Image = Grey_scale;

            System.Drawing.Image High_Filtered = ImageFilterGS(Grey_scale);

            Fourier_Image.Image = High_Filtered;
            filter_name.Text = "Greyscale";
            trans_name.Text = "High Pass Filter";
        }

        public Bitmap ImageFilterGS(Bitmap OriginalImage)
        {
            Bitmap image = OriginalImage;
            Bitmap image2 = new Bitmap(image.Width, image.Height);

            int[,] Filter = new int[3, 3] { { -1, -1, -1 }, { -1, 8, -1 }, { -1, -1, -1 }, };
        
            int range = (int)Math.Floor(Convert.ToDouble(Filter.GetLength(0) / 2));

            for (int m = range; m < image.Width - range; m++)
            {
                for (int n = range; n < image.Height - range; n++)
                {

                    int[,] roi = new int[Filter.GetLength(0), Filter.GetLength(0)];

                    int tmpi = 0;
                    int tmpj = 0;

                    int newValue = 0;

                    for (int i = m - range; i < m + range + 1; i++)
                    {
                        for (int j = n - range; j < n + range + 1; j++)
                        {
                            Color pixel = image.GetPixel(i, j);
                            Double p = Convert.ToDouble((pixel.R * 0.3) + (pixel.G * 0.59) + (pixel.B * 0.11));

                            roi[tmpi, tmpj] = (int)p;

                            tmpj++;
                        }

                        tmpi++;
                        tmpj = 0;
                    }


                    for (int k = 0; k < Filter.GetLength(0); k++)
                    {
                        for (int l = 0; l < Filter.GetLength(0); l++)
                        {
                            newValue += roi[k, l] * Filter[k, l];
                        }
                    }
                    
                    if (newValue > 255) newValue = 255;
                    if (newValue < 0) newValue = 0;

                    image2.SetPixel(m, n, Color.FromArgb(255, newValue, newValue, newValue));

                }
            }
            
            return image2;
        }

        private void IDFT_HP_Button_Click(object sender, EventArgs e)
        {
            System.Drawing.Image original = System.Drawing.Image.FromFile(base_file_path);
            Bitmap original_map = GetArgbCopy(original);
            Grayscale filter = new Grayscale(0.3, 0.59, 0.11);
            Bitmap Grey_scale = filter.Apply(original_map);

            filtered_image.Image = Grey_scale;

            System.Drawing.Image High_Filtered = ImageFilterGS(Grey_scale);

            filtered_image.Image = High_Filtered;

            Grey_scale = GetArgbCopy(High_Filtered);

            High_Filtered = ImageFilterGS(Grey_scale);

            Bitmap Filtered_map = GetArgbCopy(High_Filtered);

            Filtered_map = filter.Apply(Filtered_map);

            ComplexImage GreyImage = ComplexImage.FromBitmap(Filtered_map);

            GreyImage.BackwardFourierTransform();

            Bitmap image = GreyImage.ToBitmap();

            Fourier_Image.Image = image;

            filter_name.Text = "High Pass Filter";
            trans_name.Text = "IDFT on High Pass Filter";
        }

        private void Pencil_Button_Click(object sender, EventArgs e)
        {
            System.Drawing.Image original = System.Drawing.Image.FromFile(base_file_path);
            Bitmap original_map = GetArgbCopy(original);
            Grayscale filter = new Grayscale(0.3, 0.59, 0.11);
            Bitmap Grey_scale = filter.Apply(original_map);
            filtered_image.Image = Grey_scale;
            Merge merge_filter = new Merge(Grey_scale);

            Invert invert_filter = new Invert();

            Bitmap invert = invert_filter.Apply(Grey_scale);
            
            GaussianBlur blur = new GaussianBlur();

            blur.ApplyInPlace(invert);

            merge_filter.Apply(invert);

            invert = ImageFilterGS(invert);

            BrightnessCorrection bright_filter = new BrightnessCorrection(10);

            bright_filter.ApplyInPlace(invert);

            invert = ConvertToFormat(invert, PixelFormat.Format24bppRgb);

            invert_filter.ApplyInPlace(invert);

            GammaCorrection contrast_filter = new GammaCorrection(0.1);

            contrast_filter.ApplyInPlace(invert);

            Fourier_Image.Image = invert;

            filter_name.Text = "Greyscale";
            trans_name.Text = "Pencil Sketch";
        }

        public Bitmap ImageFilterLow(Bitmap OriginalImage)
        {
            Bitmap image = OriginalImage;
            Bitmap image2 = new Bitmap(image.Width, image.Height);
            double[,] Filter = new double[3, 3] { { 0.1111, 0.1111, 0.1111 }, { 0.1111, 0.1111, 0.1111 }, { 0.1111, 0.1111, 0.1111 }, };

            double prod = -50;
            foreach(int value in Filter)
            {
                prod *= value;
            }

            int range = (int)Math.Floor(Convert.ToDouble(Filter.GetLength(0) / 2));

            for (int m = range; m < image.Width - range; m++)
            {
                for (int n = range; n < image.Height - range; n++)
                {

                    Double[,] roi = new Double[Filter.GetLength(0), Filter.GetLength(0)];

                    int tmpi = 0;
                    int tmpj = 0;

                    int newValue = 0;

                    for (int i = m - range; i < m + range + 1; i++)
                    {
                        for (int j = n - range; j < n + range + 1; j++)
                        {
                            Color pixel = image.GetPixel(i, j);
                            Double p = Convert.ToDouble((pixel.R * 0.3) + (pixel.G * 0.59) + (pixel.B * 0.11));

                            roi[tmpi, tmpj] = p;

                            tmpj++;
                        }

                        tmpi++;
                        tmpj = 0;
                    }


                    for (int k = 0; k < Filter.GetLength(0); k++)
                    {
                        for (int l = 0; l < Filter.GetLength(0); l++)
                        {
                            newValue += (int)(roi[k, l] * Filter[k, l]);
                        }
                    }

                    if (newValue > 255) newValue = 255;
                    if (newValue < 0) newValue = 0;

                    image2.SetPixel(m, n, Color.FromArgb(255, newValue, newValue, newValue));

                }
            }


            return image2;
        }

        public static Bitmap ConvertToFormat(System.Drawing.Image image, PixelFormat format)
        {
            Bitmap copy = new Bitmap(image.Width, image.Height, format);
            using (Graphics gr = Graphics.FromImage(copy))
            {
                gr.DrawImage(image, new Rectangle(0, 0, copy.Width, copy.Height));
            }
            return copy;
        }
    }
}
