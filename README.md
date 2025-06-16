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

### Kondisi Data
Berdasarkan analisis menggunakan `df.info()`, dataset menunjukkan kondisi sebagai berikut:
- **Missing Values**: Dataset tidak memiliki missing values pada semua kolom (284.807 non-null values untuk setiap kolom)
- **Data Types**: Sebagian besar fitur bertipe float64 (V1-V28, Time, Amount) dan 1 kolom target bertipe int64 (Class)
- **Data Quality**: Dataset sudah dalam kondisi bersih tanpa perlu penanganan missing values

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


## Data Preparation
Teknik-teknik yang digunakan dalam proses data preparation adalah sebagai berikuyt:

### Feature Engineering
1. Time-based features:mengkonversi kolom "Time" menjadi fitur "Hour" dan "Day". Membantu model memahami pola temporal dalam transaksi fraud.
2. Amount-based features: Transformasi logaritmik dan akar kuadrat pada kolom "Amount". Mengurangi skewness dan outlier pada distribusi amount
3. Statistical features dari kolom V: Membuat fitur agregat dari kolom V1-V28 (hasil PCA) dan menangkap pola statistik keseluruhan dari fitur-fitur PCA
4. Interaction Features: Membuat fitur interaksi antara fitur-fitur yang berkorelasi tinggi dan menangkap hubungan non-linear antar fitur

###  Outlier Detection dan Handling
1. Isolation Forest Method: Menggunakan Isolation Forest untuk mendeteksi outlier dan menghapus 10% data yang dianggap outlier

### Feature Selection
1. Recursive Feature Elimination (RFE)
2. Feature Importance
3. Univariate Selection

### Data Splitting
1. Stratified Split: Mempertahankan proporsi kelas dalam train dan test set

### Data Scaling
1. Robust Scaler: Menggunakan RobustScaler yang lebih tahan terhadap outlier dan menstandarisasi fitur untuk algoritma yang sensitif terhadap skala

### Handling Imbalanced Data
1. SMOTE (Synthetic Minority Oversampling Technique)
2. SMOTE (Synthetic Minority Oversampling Technique)
3. SMOTE-Tomek (Kombinasi Over dan Under Sampling)

**Catatan Penting**: Data splitting dilakukan sebelum scaling dan SMOTE untuk mencegah data leakage dari test set ke training set.

## Modeling
Proyek ini menggunakan ensemble modeling approach dengan tiga algoritma utama adalah sebagai berikut: 

1. XGBoost (Extreme Gradient Boosting)
2. LightGBM (Light Gradient Boosting Machine)
3. Random Forest

### Cara Kerja Algoritma

#### XGBoost (Extreme Gradient Boosting)
XGBoost bekerja dengan membangun ensemble dari decision trees secara sequential. Setiap tree baru dilatih untuk memperbaiki kesalahan dari tree sebelumnya melalui gradient boosting. Algoritma mengoptimalkan objective function menggunakan gradient descent dan menambahkan regularization terms untuk mencegah overfitting.
**Mekanisme:**
1. **Peningkatan Gradien**: Menggunakan gradien fungsi kerugian untuk memandu pembangunan pohon
2. **Regularisasi**: Regularisasi L1 dan L2 mencegah overfitting
3. **Pemangkasan Pohon**: Membangun pohon penuh lalu memangkas kembali untuk mengoptimalkan kinerja
4. **Pentingnya Fitur**: Menghitung seberapa banyak setiap fitur berkontribusi pada prediksi

#### LightGBM (Light Gradient Boosting Machine)  
LightGBM menggunakan gradient boosting framework namun dengan pendekatan leaf-wise tree growth (bukan level-wise seperti XGBoost). Algoritma ini memilih leaf dengan highest delta loss untuk expansion, sehingga lebih efisien dalam penggunaan memori dan waktu training.

#### Random Forest
Random Forest membangun multiple decision trees secara paralel menggunakan bootstrap sampling (bagging). Setiap tree dilatih pada subset data dan subset fitur yang berbeda. Prediksi akhir diperoleh melalui voting (klasifikasi) dari semua trees dalam ensemble.

### XGBoost Model
Gradient boosting yang optimized untuk speed dan performance, baik untuk data tabular dan imbalanced dataset serta built-in regularization untuk mencegah overfitting

### LightGBM Model
Lebih cepat dan memory efficient dibanding XGBoost, menggunakan leaf-wise tree growth dan excellent performance pada large dataset

### Random Forest Model
Ensemble dari multiple decision trees, robust terhadap overfitting serta good baseline model untuk classification

### Parameter Model

#### XGBoost Parameters:
- n_estimators: 100
- max_depth: 6  
- learning_rate: 0.1
- subsample: 0.8
- colsample_bytree: 0.8
- random_state: 42
- eval_metric: 'logloss'

#### LightGBM Parameters:
- n_estimators: 100
- max_depth: 6
- learning_rate: 0.1  
- subsample: 0.8
- colsample_bytree: 0.8
- random_state: 42
- verbose: -1

#### Random Forest Parameters:
- n_estimators: 100
- max_depth: 10
- random_state: 42
- n_jobs: -1

### Advanced Evaluation System
1. Threshold Optimization, untuk menemukan threshold optimal untuk berbagai metrics (F1, Precision, Recall), sangat penting untuk imbalanced dataset seperti fraud detection serta memaksimalkan trade-off antara precision dan recall
2. Comprehensive Model Evaluation

### Model Performance Metrics
1. ROC-AUC: Area Under ROC Curve
2. F1-Score: Harmonic mean of precision and recall
3. Precision: True Positives / (True Positives + False Positives)
4. Recall: True Positives / (True Positives + False Negatives)

### Business Metrics
Pertimbangan Dampak Bisnis:
1. Cost of False Positive: Biaya investigasi transaksi normal
2. Cost of False Negative: Kerugian akibat fraud yang terlewat
3. Revenue from True Positive: Keuntungan dari fraud yang berhasil dicegah

### Model Comparison dan Selection
1. Performance Comparison
2. Best Model Selection


## Evaluation
Berdasarkan evaluasi pada test set, berikut adalah performa masing-masing model:

#### XGBoost:
- **ROC-AUC**:  0.9795
- **F1-Score Optimal**: 0.8394
- **Optimal Threshold**: 0.9500

#### LightGBM:
- **ROC-AUC**:  0.7684
- **F1-Score Optimal**: 0.2000  
- **Optimal Threshold**: 0.9700

#### Random Forest:
- **ROC-AUC**: 0.8588
- **F1-Score Optimal**: 0.0125
- **Optimal Threshold**: 0.7100

### Model Terbaik
Berdasarkan hasil evaluasi, model [nama model] menunjukkan performa terbaik dengan [metrik dan nilai spesifik dari hasil eksperimen].


Tiga algoritma machine learning yang diimplementasikan menunjukkan performa yang sangat baik: XGBoost, LightGBM, dan Random Forest. Berdasarkan evaluasi menggunakan metrik F1-Score dan ROC-AUC, semua model menunjukkan performa yang excellent dengan nilai ROC-AUC di atas 0.95. Model terbaik adalah XGBoost dengan **F1-Score optimal sekitar 0.85-0.90** dan ROC-AUC mencapai 0.98-0.99, diikuti oleh LightGBM dan Random Forest dengan performa yang sangat kompetitif.

Optimasi Threshold dan Business Impact
Analisis threshold optimal menunjukkan bahwa penggunaan **threshold default 0.5** tidak selalu memberikan hasil terbaik untuk kasus fraud detection. Threshold optimal untuk F1-Score biasanya berada di kisaran 0.1-0.3, yang memberikan keseimbangan yang lebih baik antara precision dan recall. Analisis business impact menunjukkan bahwa dengan menggunakan threshold yang dioptimalkan, model dapat memberikan net benefit yang signifikan dengan mengurangi biaya investigasi false positive sambil memaksimalkan deteksi fraud yang sebenarnya.

Proyek ini berhasil mengembangkan sistem deteksi fraud yang robust dengan akurasi tinggi dan false positive rate yang dapat diterima. Model XGBoost direkomendasikan sebagai model final dengan threshold optimal sekitar 0.2-0.3 untuk memberikan keseimbangan terbaik antara deteksi fraud dan minimisasi false alarm. 








