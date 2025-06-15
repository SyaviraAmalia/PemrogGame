# Credit Card Fraud Prediction
## Domain Proyek
Domain proyek dari "Credit Card Fraud Predictrion" ekonomi dan bisnis. Penipuan kartu kredit, terutama dengan meningkatnya jumlah transaksi digital, merupakan masalah besar dalam industri finansial.  Baik individu maupun bisnis dapat mengalami kerugian finansial yang besar sebagai akibat dari transaksi penipuan.  Akibatnya, sistem yang mampu mendeteksi transaksi penipuan secara otomatis dan efektif diperlukan.  Metode pengajaran mesin sangat membantu dalam mengidentifikasi pola penipuan yang didasarkan pada data historis transaksi. Berikut beberapa poin relevansinya dengan domain ekonomi dan bisnis:

1. **Mengurangi Kerugian Finansial**: Penipuan kartu kredit dapat menyebabkan kerugian jutaan dolar bagi perusahaan penyedia layanan keuangan. Dengan deteksi dini, kerugian ini dapat diminimalkan secara signifikan.
2. **Kepatuhan terhadap Regulasi**: Banyak negara mewajibkan lembaga keuangan untuk memiliki sistem pendeteksian penipuan. Implementasi model ini membantu memenuhi standar kepatuhan (compliance) dan audit.
3. **Menjaga Kepercayaan Konsumen**: Keamanan transaksi adalah fondasi dalam industri perbankan dan e-commerce. Deteksi penipuan yang efektif meningkatkan kepercayaan pelanggan terhadap bisnis.

## Business Understanding
### Problem Statement
Bagaimana membangun model machine learning yang mampu mengklasifikasikan transaksi kartu kredit sebagai penipuan atau bukan penipuan secara akurat, terutama dalam kondisi data yang sangat tidak seimbang (imbalanced)?

### Goals
Adapun tujuan dari proyek ini sebagai berikut:
1. Mengembangkan model klasifikasi untuk mendeteksi transaksi penipuan.
2. Mengurangi tingkat false negative agar transaksi penipuan tidak lolos.
3. Mengukur performa model menggunakan metrik yang sesuai seperti confusion matrix dan ROC-AUC.

### Solution Statement
Untuk mencapai tujuan tersebut, beberapa pendekatan solusi dilakukan, yaitu:
1. enggunaan Random Forest Classifier: Dipilih karena kemampuannya menangani fitur yang saling berkorelasi dan ketahanannya terhadap overfitting. Model ini dilatih pada data hasil undersampling dan dievaluasi menggunakan Precision, Recall, F1-Score, dan ROC AUC Score.
2. Eksperimen dengan XGBoost Classifier: XGBoost adalah algoritma gradient boosting yang dikenal efektif dalam menangani data imbalanced dan memiliki performa tinggi. Model XGBoost juga dievaluasi menggunakan metrik yang sama dan dibandingkan terhadap Random Forest.
3. Eksperimen dengan LightGBM Classifier: LightGBM dipilih karena efisiensinya dalam pelatihan dan kemampuannya menangani dataset besar dengan cepat. Diuji untuk melihat apakah dapat memberikan hasil lebih baik dibanding XGBoost dan Random Forest

Metode ini diharapkan dapat memenuhi tujuan proyek untuk mengembangkan model analisis prediktif yang akurat dan efisien untuk memprediksi penipuan kartu kredit.

## Data Understanding 
Dataset yang digunakan dalam proyek ini adalah Credit Card Fraud Detection Dataset yang diperoleh dari Kaggle dengan URL: https://www.kaggle.com/datasets/mlg-ulb/creditcardfraud.

### Informasi Dataset
1. Jumlah data: 284.807 baris
2. Fitur: 31 kolom (30 fitur dan 1 label)
3. Label target: Class (0 = bukan penipuan, 1 = penipuan)
4. Distribusi kelas sangat tidak seimbang: hanya 492 transaksi penipuan (sekitar 0.17%)
5. Jumlah Sampel: 284,807 transaksi
6. Tipe Data: Numerik (float64 dan int64)

### Variabel-variabel pada Credit Card Fraud Detecion adalah sebagai berikut: 
1. Time: Waktu dalam detik yang telah berlalu antara setiap transaksi dan transaksi pertama dalam dataset
2. Amount: Nilai transaksi
3. V1 hingga V28: 28 fitur numerik yang merupakan hasil transformasi Principal Component Analysis (PCA)


### Visualisasi Data
Untuk bisa memahami distribusi data dengan baik digunakan visualisasi data untuk menampilkan penyebaran, hubungan ataupun distribusi data.
![Class Distribution](/Assets/Sprites/download (11).png)

## Data Preparation








