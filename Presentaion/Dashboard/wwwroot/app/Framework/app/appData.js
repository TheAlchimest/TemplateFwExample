var operationTypes = { add: 1, view: 2, edit: 3, delete: 4, activate: 5, deactivate: 6, publish: 7, unpublish:8, businessToSp:101 };
var foundationType = { BusinessInternal: 2, Government: 3, ServiceProvider: 4, Security: 5, BusinessExternal: 6 };
const UserAccountStatusEnum = { PendingReview: 1, UnderRevision: 2, Rejected: 3, Blocked: 4, Active: 5 };
const deactivationType = { User: 1, Foundation: 2};


var messages = {
    deleteConfirmation: "هل أنت متأكد من عملية الحذف؟",
    deleteItemText: "سيتم حذف ##",
    activationConfirmation: "هل أنت متأكد من عملية التفعيل؟",
    activationItemText: "سيتم تفعيل ##",
    deactivationConfirmation: "هل أنت متأكد من عملية الإيقاف؟",    
    deactivationItemText: "سيتم إيقاف ##",

    publishConfirmation: "هل أنت متأكد من عملية النشر؟",
    publishItemText: "سيتم نشر ##",
    unpublishConfirmation: "هل أنت متأكد من عملية إيقاف النشر؟",
    unpublishItemText: "سيتم إيقاف نشر ##",

    setDefautConfirmation: "هل أنت متأكد؟",
    setDefautItemText: "سيتم تحويل ## إلي الوضع الافتراضي",
    rejectConfirmation: "هل أنت متأكد من عملية الرفض؟",
    rejectItemText: "سيتم رفض ##",
    setEnableItemText: "سيتم تفيل ## ",
    setDisableItemText: "سيتم تعطيل ## ",
    confirmButtonText: "تأكيد",
    cancelButtonText: "الغاء",
    denyButtonText: "رفض",
    errorDelete: 'فشلت عملية الحذف',
    errorActivation: 'فشلت عملية التفعيل',
    errorDeactivation: 'فشلت عملية التفعيل',
    emptyFile: 'الملف المرفق فارغ',
    makeSpAccountConfirmation: "هل أنت متأكد من عملية اضافة حساب الشركة لمزودي الخدمات؟",
    makeSpAccountItemText: "سيتم اضافة حساب مزود خدمة لشركة  ##",
};
var AccountsValidationMessages={
    EmailNotRelatedToDomain: 'يجب أن يكون البريد الالكتروني مرتبط بإسم النطاق',
    DuplicateContactEmail: 'تم ادخال  البريد الالكتروني لجهة اتصال أخرى',
    DuplicateContactMobile: 'تم ادخال الجوال لجهة اتصال أخرى',
    DuplicateContactFullName: 'تم ادخال الاسم لجهة اتصال أخرى',
    DuplicateContactIdNumber: 'تم ادخال الهوية لجهة اتصال أخرى',
    DuplicateContactPosission: 'تم ادخال المنصب لجهة اتصال أخرى',
    MustHaveAccountManager: 'يجب تحديد أحد جهات الاتصال مدير للحساب',
    MustAddContactPersons: 'يجب اضافة جهات الاتصال',
    MustAddAttachments: 'يجب اضافة المرفقات ',
    completeData: 'يجب ادخال البيانات المطلوبة ',
    NotUniqueFoundationNo: 'رقم المنشأة مكرر ',
    ServiceSelections: 'اختر واحدة او اكثر من الخدمات بالقائمةالاسم مكرر ',
    NotUniqueFoundationNameAr: 'الاسم باللغة العربية مكرر',
    NotUniqueFoundationNameEn: 'الاسم باللغة الانجليزية مكرر',
    NotUniqueIsIdNumber: 'رقم الهوية مسجل من قبل',
    AccountNotValidInAbsher: 'بيانات الرقم الهوية وتاريخ الميلاد غير صحيحه بقاعده بيانات ابشر',
    PasswordNotMatched: 'كلمة المرور غير متطابقة',
    FoundationAccountSavesSuccess: 'تم حفظ البيانات بنجاح'
};
