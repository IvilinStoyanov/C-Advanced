﻿using System;
using System.Collections.Generic;
using System.Text;


public interface INamable
{
    string Name { get; }

    void OnNameChange(NameChangeEventArgs args);
}
