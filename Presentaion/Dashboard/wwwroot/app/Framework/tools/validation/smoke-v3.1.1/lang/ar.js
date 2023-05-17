(function ($) {
    $.fn.smkValidate.Languaje = {
        textEmpty: 'بيان مطلوب',
        textEmptyCustom: 'يجب ادخال {@}',
        textEmail: 'يجب ادخال بريد الكتروني صحيح',
        textAlphanumeric: 'يُسمح فقط بأرقام وحروف',
        textEngilsh: 'يجب ادخال صيغة صحيحة',
        textArabic: 'يجب ادخال صيغة صحيحة',
        textNumber: 'يٌسمح بأرقام فقط',
        textNumberRange: 'الأرقام المسموحة يجب أن تكون أكبر من <b> {@} </b> وأقل من <b> {@} </b>',
        textDecimal: 'يُسمح فقط بالأرقام العشرية',
        textCurrency: 'يجب تعبأة الخانة بكمية نقدية ',
        textSelect: 'يجب اختيار أحد الخيارات',
        textCheckbox: 'يجب اختيار أحد الخيارات',
        textLength: 'عدد الحروف = <b> {@} </b>',
        textRange: 'عدد الحروف يجب أن يكون أكبر من <b> {@} </b> وأقل من <b> {@} </b>',
        textSPassDefault: '4 حروف على الأقل',
        textSPassWeak: '6 حروف على الأقل',
        textSPassMedium: '6 حروف ورقم على الأقل',
        textSPassStrong: 'الحد الأدنى 6 حروف بينهم رقم وحرف كبير (Capital)',
        textUrl: 'يجب ادخال رابط صحيح',
        textTel: 'يجب ادخال رقم هاتف صحيح',
        textColor: 'يجب ادخال كود لون صحيح',
        textDate: 'يجب ادخال تاريخ صحيح',
        textDatetime: 'يجب ادخال تاريخ ووقت صحيحين',
        textMonth: 'يجب ادخال شهر صحيح',
        textWeek: 'يجب ادخال أسبوع صحيح',
        textTime: 'يجب ادخال وقت صحيح',
        textPattern: 'يجب ادخال صيغة صحيحة',
        textCrNumber: 'يرجى إدخال رقم السجل التجاري بصورة صحيحة',
        textFoundationNumber: 'يرجى إدخال رقم المنشأة بصورة صحيحة',
        textDomain: 'يرجى إدخال إسم النطاق بصورة صحيحة مثال companyname.com',
        textDomainURL: 'يرجى إدخال الرابط بصورة صحيحة',
        textPostalCode: 'يجب ادخال رمز بريدي صحيح',
        textMobile: 'يجب ادخال رقم جوال صحيح مثال 0560000000',
        textPhone: 'يجب ادخال رقم هاتف صحيح',
        textExPhone: 'يجب ادخال رقم هاتف صحيح',
        textIdNumber: 'يجب ادخال رقم هوية صحيح',
        textNationalId: 'يجب ادخال رقم هوية وطنية صحيح',
        textResidencenumber: 'يجب ادخال رقم اقامة صحيح'
    };

    $.smkEqualPass.Languaje = {
        textEqualPass: 'كلمة المرور غير متطابقة'
    };

    $.smkDate.Languaje = {
        shortMonthNames: ["1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"],
        monthNames: ["يناير", "فبراير", "مارس", "ابريل", "مايو", "يونيو", "يوليو", "أغسطس", "سبتمبر", "أكتوبر", "نوفمبر", "ديسمبر"]
    };

}(jQuery));
