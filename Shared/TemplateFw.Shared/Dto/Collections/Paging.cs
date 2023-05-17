using System;

namespace TemplateFwExample.Shared.Dtos.Collections
{
    class Paging
    {
        private int _PageNo = 1;
        private int _PageSize = 10;
        private int _TotalPages;
        private int _TotalCount;
        private int _StartPage = 1;
        private int _EndPage;
        private int previousPages;
        private int _PreviousPageIndex;
        private int _NextPageIndex;
        private int _PaggingCount = 5;

        public int PageSize {
            get => this._PageSize;
            set => this._PageSize = value;
        }

        public int TotalRecords {
            get => this._TotalCount;
            set => this._TotalCount = value;
        }

        public int PageNumber {
            get => this._PageNo;
            set => this._PageNo = value;
        }

        public int StartPage {
            get => this._StartPage;
            set => this._StartPage = value;
        }

        public int EndPage {
            get => this._EndPage;
            set => this._EndPage = value;
        }

        public int TotalPages {
            get => this._TotalPages;
            set => this._TotalPages = value;
        }

        public int PreviousPageIndex {
            get => this._PreviousPageIndex;
            set => this._PreviousPageIndex = value;
        }

        public int NextPageIndex {
            get => this._NextPageIndex;
            set => this._NextPageIndex = value;
        }

        public string UrlPattern { get; set; } = "/{0}/";

        public bool IsValid { get; set; } = true;

        public int ItemNoFrom { get; set; }

        public int ItemNoTo { get; set; }

        private Paging()
        {
        }

        public Paging(
          int pageIndex,
          int totalRecords,
          int pageSize,
          int paggingCount,
          string sigularText,
          string pluralText)
        {
            this._PageNo = pageIndex;
            this._PageSize = pageSize;
            this._TotalCount = totalRecords;
            this._PaggingCount = paggingCount;
            this.PreparePagging();
        }

        public void PreparePagging()
        {
            if (this._TotalCount == 0)
            {
                this.IsValid = false;
            }
            else
            {



                if (this._PageNo > this.previousPages + 1)
                    this._StartPage = this._PageNo - this.previousPages;
                if (this._StartPage < 1)
                    this._StartPage = 1;

                this.ItemNoFrom = (this._PageNo - 1) * this._PageSize + 1;
                this.ItemNoTo = this.ItemNoFrom + this._PageSize - 1;
                if (this.ItemNoFrom > this._TotalCount)
                    this.ItemNoTo = this._TotalCount;
                this._NextPageIndex = this._PageNo >= this._TotalPages ? 0 : this._PageNo + 1;
                string str = "";
                if (this.PageSize > this._TotalCount)
                    str = Convert.ToString(this._TotalCount);
                else
                    str = Convert.ToString(this._PageNo * this.PageSize);
            }
        }
    }
}
