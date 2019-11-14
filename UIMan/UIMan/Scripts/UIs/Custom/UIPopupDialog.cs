﻿using UnuGames;

// This code is generated automatically by UIMan ViewModelGerenrator, please do not modify!

public partial class UIPopupDialog : UIManDialog
{
    private string m_title = "";

    [UIManProperty]
    public string Title
    {
        get { return this.m_title; }
        set { this.m_title = value; OnPropertyChanged(); }
    }

    private string m_content = "";

    [UIManProperty]
    public string Content
    {
        get { return this.m_content; }
        set { this.m_content = value; OnPropertyChanged(); }
    }

    private string m_labelButtonYes = "";

    [UIManProperty]
    public string LabelButtonYes
    {
        get { return this.m_labelButtonYes; }
        set { this.m_labelButtonYes = value; OnPropertyChanged(); }
    }

    private string m_labelButtonNo = "";

    [UIManProperty]
    public string LabelButtonNo
    {
        get { return this.m_labelButtonNo; }
        set { this.m_labelButtonNo = value; OnPropertyChanged(); }
    }

    private bool m_isConfirmDialog = false;

    [UIManProperty]
    public bool IsConfirmDialog
    {
        get { return this.m_isConfirmDialog; }
        set { this.m_isConfirmDialog = value; OnPropertyChanged(); }
    }
}